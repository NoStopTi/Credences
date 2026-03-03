using Credence.Application.UserContext.Passwords.UseCases.Requests;
using Credence.Application.SharedContext.Responses;

namespace Credence.Application.SharedContext.Contracts.Passwords;

public interface IForgotHandler
{
    Task<Response<string>> ForgotPasswordAsync(ForgotRequest request);
}