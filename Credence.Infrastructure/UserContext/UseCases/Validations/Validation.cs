using Flunt.Validations;

namespace Credence.Infrastructure.UserContext.UseCases.Validations;

public class Validation : Contract<string>, IValidation
{
    public Validation() { }
    public void FullStringValidation(string value, string source, string message, int? max = null, string? maxMsg = null, int? min = null, string? minMsg = null)
    {
        Requires()
              .IsNotNullOrEmpty(value, $"{source} - {message}");

        if (max != null)
            IsLowerOrEqualsThan(value ?? string.Empty, max ?? 0, $"{source}-{maxMsg}");

        if (min != null)
            IsGreaterOrEqualsThan(value ?? string.Empty, min ?? 0, $"{source}-{minMsg}");
    }
    public Validation Required(string value, string source, string message)
    {
        Requires().
             IsNotNullOrEmpty(value, $"{source} - {message}");
        return this;
    }
    public Validation Required(Guid value, string source, string message)
    {
        Requires().
             IsNotNull(value, $"{source} - {message}");
        return this;
    }
    public Validation Required(object value, string source, string message)
    {
        Requires().
             IsNotNull(value, $"{source} - {message}");
        return this;
    }
    public Validation LowerOrEqualsThan(string value, string source, string message)
    {
        IsNotNullOrEmpty(value, $"{source} - {message}");
        return this;
    }
    public Validation GreaterOrEqualsThan(string value, string source, string message)
    {
        IsNotNullOrEmpty(value, $"{source} - {message}");
        return this;
    }
    public Validation EmailAddress(string value, string source, string message)
    {
        IsEmail(value, $"{source} - {message}");
        return this;
    }

}