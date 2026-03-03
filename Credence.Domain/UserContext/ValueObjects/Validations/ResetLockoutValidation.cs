using Credence.Domain.UserContext.Entities;

namespace Credence.Domain.UserContext.ValueObjects.Validations;

public class ResetLockoutValidation
{
    public ResetLockoutValidation(User user, string source)
    {
        new PasswordExpireValidation(user.PasswordExpire ?? null!, source);
        new LockoutEndValidation(user.LockoutEnd ?? DateTimeOffset.MaxValue, source);
        new LockoutEnabledValidation(user.LockoutEnabled, source);
    }  
}