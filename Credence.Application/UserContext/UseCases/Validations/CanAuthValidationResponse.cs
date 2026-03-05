using Credence.Application.UserContext.Login.UseCases.Enums;

namespace Credence.Application.UserContext.UseCases.Validations;

public class CanAuthValidationResponse
{
    public CanAuthValidationResponse(ELockoutType lockout, TimeSpan? remaining)
    {
        LockoutType = lockout;
        RemainingLockoutTime = remaining;
    }
    public ELockoutType LockoutType { get; private set; }
    public TimeSpan? RemainingLockoutTime { get; private set; }
    public static CanAuthValidationResponse UserAccountNotLocked() =>
                                                                    new CanAuthValidationResponse(ELockoutType.None, TimeSpan.Zero);
}

