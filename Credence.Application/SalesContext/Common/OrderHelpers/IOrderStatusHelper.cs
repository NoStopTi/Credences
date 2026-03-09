using Credence.Application.SharedContext.Responses;
using Credence.Domain.SalesContext.Entities;

namespace Credence.Application.SalesContext.Common.OrderHelpers;

public interface IOrderStatusHelper
{
    Response<Order?> ResponseByStatus(Order order, int erroNumber, string message);
}