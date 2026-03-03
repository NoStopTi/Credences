using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.EmailNotifications;

public interface ITwoFactorTokenService
{
       Task SendTwoFactorTokenAsync(string tokenUrl, string displayName, string to);
       Task<string> BuildToken(User user, string provider);
}