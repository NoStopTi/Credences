using Credence.Default.Constants.PasswordContext;
using Flunt.Validations;

namespace Credence.Domain.UserContext.ValueObjects.Validations;

public class LockoutEndValidation : Contract<Password>
{
    public LockoutEndValidation(DateTimeOffset value, string source)
    {
        Requires()
            .IsLowerThan(value.Date,
                            DateTimeOffset.UtcNow.Date,
                            source,
                            PasswordConst.MaxMsg);
    }

}