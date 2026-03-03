using Credence.Default.Constants.PasswordContext;
using Flunt.Validations;

namespace Credence.Domain.UserContext.ValueObjects.Validations;

public class LockoutEnabledValidation : Contract<Password>
{
    public LockoutEnabledValidation(bool value, string source)
    {
        Requires()
            .IsTrue(value, source, PasswordConst.MaxMsg);
    }

}