using Credence.Default.Constants.PasswordContext;
using Flunt.Validations;

namespace Credence.Domain.UserContext.ValueObjects.Validations;

public class PasswordValidation : Contract<Password>
{
    public PasswordValidation(Password password, string source)
    {
        Requires()
        .IsNotNullOrEmpty(password.Passwd, PasswordConst.Required)
            .IsLowerThan(password.Passwd,
                            PasswordConst.Max,
                           source,
                            PasswordConst.MaxMsg)

            .IsGreaterThan(password.Passwd,
                          PasswordConst.Min,
                         source,
                          PasswordConst.MinMsg);
    }
       
}