

using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.UserContext.ValueObjects.Validations;

namespace Credence.Domain.UserContext.ValueObjects;

public class PasswordExpire : ValueObject
{
    public PasswordExpire(DateTime passwordChangedAt)
    {
        PasswordChangedAt = passwordChangedAt;
    }

    public DateTime PasswordChangedAt { get; private set; }

    public void SetPasswordChangedAt(DateTime value)
    {
        PasswordChangedAt = value;
    }
    public bool IsExpired(DateTime value)
    {
        if (PasswordChangedAt == DateTime.MinValue) return false;

        return value.Date >= PasswordChangedAt.Date;
    }


    public static implicit operator PasswordExpire(DateTime date)
        => new PasswordExpire(date);

    public static implicit operator DateTime(PasswordExpire expiration)
        => expiration.PasswordChangedAt;

    public override string ToString()
        => PasswordChangedAt.ToString("u");

    public bool Validate(string source)
    {
        AddNotifications(new PasswordExpireValidation(this, source));
        return IsValid;
    }
}