

using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.EmailNotifications;

public interface IConfirmationService
{
       Task SendEmailConfirmationAsync(string tokenUrl, string displayName, string to);
       Task<string> BuildToken(User user);
}