using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.Voucher.Requests;

public class GetVoucherByNumberRequest : Request
{
    public string Number { get; private set; } = string.Empty;
}