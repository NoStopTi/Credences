using Credence.Application.UserContext.Passwords.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.SharedContext.Contracts.Passwords;

public interface IResetHandler
{
    Task<Response<IdentityResult>> ResetPasswordAsync(ResetRequest request);
}