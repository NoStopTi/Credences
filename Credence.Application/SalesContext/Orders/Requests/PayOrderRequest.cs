using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.Orders.Requests;

public class PayOrderRequest : Request
{
    public string OrderNumber { get; private set; } = string.Empty;
    public string ExternalReference { get; private set; } = string.Empty;

}
