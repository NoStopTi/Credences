using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.Orders.Requests;

public class RefundOrderRequest : Request
{
    public long Id { get; private set; }

}
