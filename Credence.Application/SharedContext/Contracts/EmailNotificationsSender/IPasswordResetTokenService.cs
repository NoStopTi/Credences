
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.EmailNotifications;

public interface IPasswordResetTokenService
{
       Task SendEmailResetTokenAsync(string tokenUrl, string displayName, string to);
       Task<string> BuildToken(User user);
}