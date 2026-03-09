using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.Orders.Requests;

public class GetOrderByNumberRequest : Request
{
    public string Number { get; private set; } = string.Empty;

}
