using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Application.SharedContext.Responses;
using Credence.Application.UserContext.TwoFactor.UseCases.Responses;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.UserContext.TwoFactor.UseCases.Services;

public class TwoFactorControlService(UserManager<User> userManager) : IVerifyCodeService, IEnableDisableService
{
    public async Task<bool> IsValidCodeAsync(User user, string provider, string code)
                                                    => await userManager.VerifyTwoFactorTokenAsync(user, provider, code);

    public async Task<Response<EnableDisableResponse>> EnableDisableAsync(User user, bool enableDisable)
    {
        var toggleResult = await userManager.SetTwoFactorEnabledAsync(user, enableDisable);

        var recoveryCodes = await userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10) ?? [];

        return ResponseEnableDisableAsync(toggleResult.Succeeded, enableDisable, recoveryCodes);
    }

    private Response<EnableDisableResponse> ResponseEnableDisableAsync(bool identityResult, bool enableDisable, IEnumerable<string> recoveryCodes)
    {
        return identityResult ? new Response<EnableDisableResponse>(new(recoveryCodes.ToArray(), enableDisable), StatusCodes.Status200OK, TwoFactorConst.Enabled2FA(enableDisable))
                              : new Response<EnableDisableResponse>(null, StatusCodes.Status200OK, TwoFactorConst.Enabled2FA(enableDisable));
    }

}
