using Credence.Application.SharedContext.Contracts.Passwords;
using Credence.Application.UserContext.Exceptions;
using Credence.Application.UserContext.Passwords.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Default.Constants.PasswordContext;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.UserContext.Passwords.UseCases;


public class ResetHandler(
                            UserManager<User> userManager
                          ) : IResetHandler
{

    public async Task<Response<IdentityResult>> ResetPasswordAsync(ResetRequest request)
    {
        request.PasswordValidate();

        User user = await userManager.FindByEmailAsync(request.Email) ?? null!;

        var identityResult = await userManager.ResetPasswordAsync(user, request.Token.Decoded_UTF8_Base64(), request.Password);

        if (!identityResult.Succeeded) throw new ResetPasswordException($"{PasswordConst.PwdResetAction} - {identityResult}");

        await userManager.ResetAccessFailedCountAsync(user);

        user.ResetLockout();

        await userManager.UpdateAsync(user);

        return new Response<IdentityResult>(identityResult, StatusCodes.Status200OK);
    }
}