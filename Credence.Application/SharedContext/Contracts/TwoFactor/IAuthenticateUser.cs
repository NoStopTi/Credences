
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.TwoFactor;

public interface IAuthenticateUser
{
    Task SignInAsync(User user, bool rememberMe);
}