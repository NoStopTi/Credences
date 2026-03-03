using Credence.Default.Constants.PasswordContext;
using Flunt.Validations;

namespace Credence.Domain.UserContext.ValueObjects.Validations;

public class ConfirmPasswordValidation : Contract<Password>
{
    public ConfirmPasswordValidation(Password password,string source)
    {
        Requires()
        .AreEquals(password.Passwd, password.ConfirmPassword, nameof(password))
        .IsNotNullOrEmpty(password.Passwd, $"{source}-{PasswordConst.MaxMsg}")
            .IsGreaterThan(password.Passwd,
                            PasswordConst.Max,
                            nameof(Password.Passwd),
                            $"{source}-{PasswordConst.MaxMsg}")
            .IsLowerThan(password.Passwd,
                            PasswordConst.Min,
                            nameof(Password.Passwd),
                            $"{source}-{PasswordConst.MinMsg}");
    }

}