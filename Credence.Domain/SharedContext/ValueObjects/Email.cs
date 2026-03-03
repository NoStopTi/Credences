
// using Flunt.Notifications;

using Credence.Domain.SharedContext.ValueObjects.Validations;

namespace Credence.Domain.SharedContext.ValueObjects;

public class Email : ValueObject
{
    public Email(string address)
    {
        Address = address.Trim().ToLower();

    }
    public string Address { get; private set; }

    public static implicit operator Email(string address)
                                                => new Email(address);

    public static implicit operator string(Email email)
                                                => email.Address;
    public override string ToString()
                                    => Address.ToString();

    public bool Validate(string source)
    {
        AddNotifications(new EmailValidation(this, source));
        return IsValid;
    }

}
