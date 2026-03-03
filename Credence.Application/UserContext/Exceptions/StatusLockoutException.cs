namespace Credence.Application.UserContext.Services.AccountStatus.Exceptions;
public class StatusLockoutException : Exception
{
    public StatusLockoutException(string message) : base(message)
    {

    }
}
