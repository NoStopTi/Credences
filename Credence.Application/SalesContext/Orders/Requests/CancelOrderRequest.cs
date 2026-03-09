using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.Orders.Requests;

public class CancelOrderRequest : Request
{
    public long longId { get; private set; }
}
