using System.Text;
using System.Text.Encodings.Web;
using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Application.UserContext.TwoFactor.UseCases.Responses;
using Credence.Application.SharedContext.Responses;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.UserContext.TwoFactor.UseCases.Services;

public class SetupTwoFactorService(UserManager<User> userManager) : ISetupTwoFactorService
{
    public async Task<Response<WithAppSetupResponse>> AppVerifySetupTwoFactor(User user)
    {
        string key = await AuthenticatorKey(user);

        var result = await Setup2FAResponse(user, key);

        return new Response<WithAppSetupResponse>(result);
    }

    private async Task<string> AuthenticatorKey(User user)
    {
        var authenticatorKey = await userManager.GetAuthenticatorKeyAsync(user);

        if (string.IsNullOrEmpty(authenticatorKey))
        {
            await userManager.ResetAuthenticatorKeyAsync(user);
            authenticatorKey = await userManager.GetAuthenticatorKeyAsync(user);
        }

        return authenticatorKey ?? null!;
    }
    private async Task<WithAppSetupResponse> Setup2FAResponse(User user, string authenticatorKey)
    {
        string sharedKey = FormatKey(authenticatorKey);
        string authenticatorUri = GenerateQrCodeUri(user.Email ?? null!, authenticatorKey);
        bool isTwoFactorEnabled = await userManager.GetTwoFactorEnabledAsync(user);

        var authResponseSetup = new
        WithAppSetupResponse(sharedKey, authenticatorUri, isTwoFactorEnabled);

        return authResponseSetup;
    }
    private string FormatKey(string unformattedKey)
    {
        var result = new StringBuilder();
        int currentPosition = 0;

        while (currentPosition + 4 < unformattedKey.Length)
        {
            result.Append(unformattedKey.Substring(currentPosition, 4)).Append(" ");
            currentPosition += 4;
        }

        if (currentPosition < unformattedKey.Length)
            result.Append(unformattedKey.Substring(currentPosition));

        return result.ToString().ToLowerInvariant();
    }
    private string GenerateQrCodeUri(string email, string unformattedKey)
    {
        return string.Format(
            TwoFactorConst.QrCode,
            UrlEncoder.Default.Encode(TwoFactorConst.DisplayNameAppAuth),
            UrlEncoder.Default.Encode(email),
            unformattedKey);
    }

}