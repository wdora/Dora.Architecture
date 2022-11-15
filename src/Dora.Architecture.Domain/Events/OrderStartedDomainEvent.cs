using Dora.Architecture.Domain.AggregatesModel.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dora.Architecture.Domain.Events;

public class OrderStartedDomainEvent : INotification
{
    public OrderStartedDomainEvent(Order order, int buyerId, string userName, Address address)
    {
        Order = order;
        BuyerId = buyerId;
        UserName = userName;
        Address = address;
    }

    public Order Order { get; }
    public int BuyerId { get; }
    public string UserName { get; }
    public Address Address { get; }
}
