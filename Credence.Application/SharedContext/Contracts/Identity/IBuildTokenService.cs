
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.Identity;

public interface IBuildTokenService
{
       Task<string> BuildToken(User user);
}