using Credence.Application.UserContext.Register.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.SharedContext.Contracts.Register;

public interface IRegisterService
{
    Task<Response<IdentityResult>> RegisterUserAsync(RegisterUserRequest request);
}