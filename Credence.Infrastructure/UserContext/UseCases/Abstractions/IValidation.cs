namespace Credence.Infrastructure.UserContext.UseCases.Validations;

public interface IValidation
{
    void FullStringValidation(string value, string source, string message, int? max = null, string? maxMsg = null, int? min = null, string? minMsg = null);
    Validation Required(string value, string source, string message);
    Validation Required(object value, string source, string message);
    Validation Required(Guid value, string source, string message);
    Validation LowerOrEqualsThan(string value, string source, string message);
    Validation GreaterOrEqualsThan(string value, string source, string message);
    Validation EmailAddress(string value, string source, string message);
}