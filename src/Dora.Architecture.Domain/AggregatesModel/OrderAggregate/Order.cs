using Dora.Architecture.Domain.Events;
using Dora.Architecture.Domain.SeedWork;

namespace Dora.Architecture.Domain.AggregatesModel.OrderAggregate;

public class Order
    : Entity, IAggregateRoot
{
    // DDD Patterns comment
    // Using private fields, allowed since EF Core 1.1, is a much better encapsulation
    // aligned with DDD Aggregates and Domain Entities (Instead of properties and property collections)
    private DateTime _orderDate;

    // Address is a Value Object pattern example persisted as EF Core 2.0 owned entity
    public Address Address { get; private set; }

    public OrderStatus OrderStatus { get; private set; }

    private int _orderStatusId;

    // Draft orders have this set to true. Currently we don't check anywhere the draft status of an Order, but we could do it if needed
    private bool _isDraft;

    // DDD Patterns comment
    // Using a private collection field, better for DDD Aggregate's encapsulation
    // so OrderItems cannot be added from "outside the AggregateRoot" directly to the collection,
    // but only through the method OrderAggrergateRoot.AddOrderItem() which includes behaviour.
    private readonly List<OrderItem> _orderItems;
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

    public int BuyerId { get; private set; }

    public static Order NewDraft()
    {
        var order = new Order();
        order._isDraft = true;
        return order;
    }

    protected Order()
    {
        _orderItems = new List<OrderItem>();
        _isDraft = false;
    }

    public Order(int buyerId, string userName, Address address) : this()
    {
        BuyerId = buyerId;
        _orderStatusId = OrderStatus.Submitted.Id;
        _orderDate = DateTime.UtcNow;
        Address = address;
        
        AddDomainEvent(new OrderStartedDomainEvent(this, buyerId, userName, address));
    }

    // DDD Patterns comment
    // This Order AggregateRoot's method "AddOrderitem()" should be the only way to add Items to the Order,
    // so any behavior (discounts, etc.) and validations are controlled by the AggregateRoot 
    // in order to maintain consistency between the whole Aggregate. 
    public void AddOrderItem(int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
    {
        var existingOrderForProduct = _orderItems.Where(o => o.ProductId == productId)
            .SingleOrDefault();

        if (existingOrderForProduct != null)
        {
            //if previous line exist modify it with higher discount  and units..

            if (discount > existingOrderForProduct.Discount)
            {
                existingOrderForProduct.SetNewDiscount(discount);
            }

            existingOrderForProduct.AddUnits(units);
        }
        else
        {
            //add validated new order item

            var orderItem = new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
            _orderItems.Add(orderItem);
        }
    }

    public void SetAwaitingValidationStatus()
    {
        if (_orderStatusId == OrderStatus.Submitted.Id)
        {
            _orderStatusId = OrderStatus.AwaitingValidation.Id;
        }
    }


    public decimal GetTotal()
    {
        return _orderItems.Sum(o => o.Units * o.UnitPrice);
    }
}
