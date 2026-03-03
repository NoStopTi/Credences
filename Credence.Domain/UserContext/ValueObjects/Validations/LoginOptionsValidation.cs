using Credence.Default.Constants.PasswordContext;
using Flunt.Validations;

namespace Credence.Domain.UserContext.ValueObjects.Validations;

public class LoginOptionsValidation : Contract<LoginOptions>
{
    public LoginOptionsValidation(LoginOptions expiration, string source)
    {

        if (expiration.LastLogin != DateTime.MinValue)
            Requires()
                .IsGreaterThan(
                    expiration.LastLogin,
                    DateTime.UtcNow,
                    source,
                    PasswordConst.PwdExpireInvalidDate
                );
    }
}