using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.Login;

public interface ISetLastLogin
{
    Task SetLastLoginAsync(User user);
}