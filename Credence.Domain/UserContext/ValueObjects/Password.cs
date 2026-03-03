using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.UserContext.ValueObjects.Validations;


namespace Credence.Domain.UserContext.ValueObjects;

public class Password : ValueObject
{
    public Password() { }
    public Password(string passwd)
    {
        Passwd = passwd;
    }

    public Password(string passwd, string confirmPassword)
    {
        Passwd = passwd;
        ConfirmPassword = confirmPassword;
    }

    public string Passwd { get; private set; } = string.Empty;
    public string ConfirmPassword { get; private set; } = string.Empty;

    public bool Validate(string source)
    {
         AddNotifications(new PasswordValidation(this, source));
        return IsValid;
    }
    // public static implicit operator Password(string passwd) => new Password(passwd);

    // public static implicit operator string(Password passwd) => new Password(passwd).Passwd;


}