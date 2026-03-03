namespace Credence.Domain.SharedContext.ValueObjects;

public class Gender : ValueObject
{
    public Gender(EGender value)
    {
        Value = value;
    }

    public EGender Value { get; private set; }

    public override string ToString()
                                    => Value.ToString();

    // public bool Validate(string source)
    // {
    //     AddNotifications(new GenderValidation(this, source));
    //     return IsValid;
    // }

}
