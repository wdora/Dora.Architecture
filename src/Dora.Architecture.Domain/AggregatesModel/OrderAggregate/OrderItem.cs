using Dora.Architecture.Domain.Exceptions;
using Dora.Architecture.Domain.SeedWork;

namespace Dora.Architecture.Domain.AggregatesModel.OrderAggregate;

public class OrderItem
    : Entity
{
    public int ProductId { get; private set; }
    public int Units { get; private set; }
    public decimal Discount { get; private set; }
    public decimal UnitPrice { get; private set; }
    public string PictureUrl { get; private set; }
    public string ProductName { get; private set; }

    protected OrderItem() { }

    public OrderItem(int productId, string productName, decimal unitPrice, decimal discount, string PictureUrl, int units = 1)
    {
        if (units <= 0)
        {
            throw new OrderingDomainException("Invalid number of units");
        }

        if ((unitPrice * units) < discount)
        {
            throw new OrderingDomainException("The total of order item is lower than applied discount");
        }

        ProductId = productId;

        ProductName = productName;
        UnitPrice = unitPrice;
        Discount = discount;
        Units = units;
        this.PictureUrl = PictureUrl;
    }

    public string GetOrderItemProductName() => ProductName;

    public void SetNewDiscount(decimal discount)
    {
        if (discount < 0)
        {
            throw new OrderingDomainException("Discount is not valid");
        }

        Discount = discount;
    }

    public void AddUnits(int units)
    {
        if (units < 0)
        {
            throw new OrderingDomainException("Invalid units");
        }

        Units += units;
    }
}
