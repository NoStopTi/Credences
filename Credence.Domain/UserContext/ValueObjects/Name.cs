using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.UserContext.ValueObjects.Validations;

namespace Credence.Domain.UserContext.ValueObjects;

public class Name : ValueObject
{
    public Name()
    {

    }

    public Name(string firstName, string? lastName, string? displayName)
    {
        FirstName = firstName;
        LastName = lastName;
        DisplayName = displayName;
    }
    public string FirstName { get; private set; } = string.Empty;
    public string? LastName { get; private set; } = string.Empty;
    public string? DisplayName { get; set; } = string.Empty;
    public override string ToString() => $"{FirstName} {LastName}";
    public Name SetFirstName(string value)
    {
        FirstName = value.Trim();
        return this;
    }
    public Name SetLastName(string value)
    {
        LastName = value.Trim();
        return this;
    }
    public Name SetDisplayName(string value)
    {
        DisplayName = value.Trim();
        return this;
    }
    public bool Validate(string source)
    {
        AddNotifications(new NameValidation(this, source));
        return IsValid;
    }

}