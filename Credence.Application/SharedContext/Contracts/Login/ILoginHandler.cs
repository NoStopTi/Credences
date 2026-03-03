using Credence.Application.SharedContext.Responses;
using Credence.Application.UserContext.Login.UseCases.Requests;
using Credence.Application.UserContext.Login.UseCases.Responses;

namespace Credence.Application.UserContext.UseCases.Login.Contracts;

public interface ILoginHandler
{
    Task<Response<LoginResponse>> Login(LoginUserRequest request);
}
