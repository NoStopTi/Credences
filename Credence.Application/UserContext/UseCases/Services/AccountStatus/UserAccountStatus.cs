namespace Credence.Application.UserContext.UseCases.Services.AccountStatus;

public class UserAccountStatus
{
    protected UserAccountStatus() { }

    public UserAccountStatus(
        bool emailConfirmed,
        bool lockoutEnabled,
        bool isLockedOut,
        DateTimeOffset? lockoutEnd,
        int accessFailedCount
    )
    {
        EmailConfirmed = emailConfirmed;
        LockoutEnabled = lockoutEnabled;
        IsLockedOut = isLockedOut;
        LockoutEnd = lockoutEnd;
        AccessFailedCount = accessFailedCount;
    }

    public bool EmailConfirmed { get; }
    public bool LockoutEnabled { get; }
    public bool IsLockedOut { get; }
    public DateTimeOffset? LockoutEnd { get; }
    public int AccessFailedCount { get; }
  }
