using Credence.Application.SalesContext.Order.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Domain.SalesContext.Entities;
using Credence.Infrastructure.SharedContext.UseCases.Responses;

namespace Credence.Application.SharedContext.Contracts.Sales;

public interface IOrderHandler
{
    Task<Response<Order?>> CancelAsync(CancelOrderRequest request);
    Task<Response<Order?>> CreateAsync(CreateOrderRequest request);
    Task<Response<Order?>> PayAsync(PayOrderRequest request);
    Task<Response<Order?>> RefundAsync(RefundOrderRequest request);
    Task<PagedResponse<List<Order>>> GetAllAsync(GetAllOrdersRequest request);
    Task<PagedResponse<List<Order>>> GetByNumberAsync(GetOrderByNumberRequest request);
}
