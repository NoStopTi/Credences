using Credence.Application.SalesContext.Exceptions;
using Credence.Application.SharedContext.Responses;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;
using Credence.Domain.SalesContext.Entities;
using Credence.Domain.SalesContext.Enums;

namespace Credence.Application.SalesContext.Common.OrderHelpers;

public class OrderStatusHelper : IOrderStatusHelper
{
    public Response<Order?> ResponseByStatus(Order order, int erroNumber, string message)
    {
        return order.Status switch
        {
            EOrderStatus.WaitingPayment => new Response<Order?>(order, erroNumber, message),
            EOrderStatus.Paid => new Response<Order?>(order, erroNumber, message),
            EOrderStatus.Canceled => new Response<Order?>(order, erroNumber, message),
            EOrderStatus.Refunded => new Response<Order?>(order, erroNumber, message),
            _ => throw new SalesException(OrderConst.InvalidEOrderStatus)
        };
    }
}
