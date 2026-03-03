using Credence.Domain.SharedContext.ValueObjects.Validations;

namespace Credence.Domain.SharedContext.ValueObjects;

public class Image : ValueObject
{
    public Image(string value)
    {
        Value = value;
    }

    public void SetImage(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }


    public static implicit operator Image(string value)
        => new Image(value);

    public static implicit operator string(Image value)
        => value;


    public override string ToString()
        => Value!.ToString();

    public bool Validate(string source)
    {
        AddNotifications(new ImageValidation(this, source));
        return IsValid;
    }
}
