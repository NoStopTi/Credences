namespace Credence.Application.SharedContext.Results;

public record Error(string code, string message)
{
    public static Error None = new(string.Empty, string.Empty);
    public static Error NullValue = new("Error.NullValue", "Um valor nulo foi fornecido.");
}
