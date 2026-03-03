namespace Credence.Application.AuthContext.UseCases.Services.Jwt.Exceptions;


public class JwtException : Exception
{
    public JwtException(string message) : base(message)
    {

    }
}