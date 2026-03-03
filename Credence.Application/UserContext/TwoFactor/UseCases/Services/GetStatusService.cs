using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.UserContext.TwoFactor.UseCases.Services;


public class GetStatusService(UserManager<User> userManager,
                                 SignInManager<User> signInManager) : IIsEnabledService
{
    public async Task<bool> IsEnabled2FA(User user)
    {

        if (!await userManager.GetTwoFactorEnabledAsync(user))
            return false;

        var validProviders = await userManager.GetValidTwoFactorProvidersAsync(user);

        if (!validProviders.Contains("Email"))
            return false;

        await signInManager.RememberTwoFactorClientAsync(user);

        return true;

    }
}
