
using Credence.Domain.SharedContext.ValueObjects;

namespace Credence.Domain.CompanyContext.ValueObjects;

public class CompanyStatus : ValueObject
{
    protected CompanyStatus() { }

    public DateTime LastStatusChanged { get; private set; } = DateTime.UtcNow;
    public bool IsActive { get; private set; } = true;

    private protected void StatusChange(bool status)
    {
        IsActive = status;
        LastStatusChanged = DateTime.UtcNow;
    }
}