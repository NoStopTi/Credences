namespace Credence.Domain.SalesContext.Entities;

public class Voucher
{
    public long Id { get; private set; }
    public string Number { get; private set; } = Guid.NewGuid().ToString("N")[..8];
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string IsActive { get; private set; } = string.Empty;
    public decimal Amount { get; private set; }
}
