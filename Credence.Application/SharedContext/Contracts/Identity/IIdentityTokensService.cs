using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts;

public interface IIdentityTokensServices
{
    Task<string> GenerateUrlTokenEmailConfirmationAsync(User user);
    Task<string> GenerateTwoFactorTokenAsync(User user, string provider);
    Task<string> GenerateUrlTokenPasswordReset(User user);

}
