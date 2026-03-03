using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Application.SharedContext.Contracts.Passwords;
using Credence.Application.SharedContext.Responses;
using Credence.Application.UserContext.Passwords.UseCases.Requests;

using Credence.Default.Constants.PasswordContext;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.UserContext.Passwords.UseCases;

public class ForgotHandler( UserManager<User> userManager,
                            IPasswordResetTokenService resetServices
                          ):IForgotHandler
{

    public async Task<Response<string>> ForgotPasswordAsync(ForgotRequest request)
    {
        var user = await userManager.FindByEmailAsync(request.Email) ?? null!;

        string token = await resetServices.BuildToken(user);

        await resetServices.SendEmailResetTokenAsync(token, user?.Name?.DisplayName ?? null!, request?.Email ?? null!);

        return new Response<string>(PasswordConst.PwdForgotTokenPWDReset);
    }
}