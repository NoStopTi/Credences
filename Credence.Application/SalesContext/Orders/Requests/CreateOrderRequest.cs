using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.Orders.Requests;

public class CreateOrderRequest : Request
{
    public long ProductId {get; private set;}
    public long? VoucherId {get; private set;}
}
