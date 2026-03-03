

using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.UserContext.ValueObjects.Validations;

namespace Credence.Domain.UserContext.ValueObjects;

public class LoginOptions : ValueObject
{
    public LoginOptions(DateTime lastLogin)
    {
        LastLogin = lastLogin;
        
    }

    public DateTime LastLogin { get; private set; }

    public void SetLastLogin(DateTime value)
    {
        LastLogin = value;
    }

    public static implicit operator LoginOptions(DateTime date)
        => new LoginOptions(date);

    public static implicit operator DateTime(LoginOptions login)
        => login.LastLogin;

    public override string ToString()
        => LastLogin.ToString("u");

    public bool Validate(string source)
    {
        AddNotifications(new LoginOptionsValidation(this, source));
        return IsValid;
    }
}