using Credence.Domain.SharedContext.ValueObject.Abstractions;
using Credence.Domain.SharedContext.ValueObjects.Validations;

namespace Credence.Domain.SharedContext.ValueObjects;

public class Age : ValueObject, IValidate
{
    public Age() { }
    public Age(int value)
    {
        Value = value;

    }
    public void SetAge(int value)
    {
        Value = value;
    }

    public int Value { get; private set; }

    public static implicit operator Age(int value)
        => new Age(value);

    public static implicit operator int(Age value)
        => value;


    public override string ToString()
        => Value.ToString();

    public bool Validate(string source)
    {
        AddNotifications(new AgeValidation(this, source));
        return IsValid;
    }

}
