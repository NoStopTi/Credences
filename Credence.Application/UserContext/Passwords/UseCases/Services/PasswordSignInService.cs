using Credence.Application.SharedContext.Contracts.Passwords;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Credence.Application.UserContext.Passwords.UseCases.Services;

public class PasswordService([FromServices] SignInManager<User> signIn,
                             [FromServices] UserManager<User> userManager
                             ) : IPasswordService
{
    public async Task<Microsoft.AspNetCore.Identity.SignInResult>
    PasswordSignInAsync(User user,
                        string password,
                        bool isPersistent = true,
                        bool lockoutOnFailure = true)
    {
        var result = await signIn.PasswordSignInAsync(user, password, isPersistent, lockoutOnFailure);
        return result;
    }

    public async Task<IdentityResult> ResetAccessFailedCountAsync(User user) =>
     await userManager.ResetAccessFailedCountAsync(user);
    public async Task<IdentityResult> AccessFailedCountAsync(User user) =>
     await userManager.AccessFailedAsync(user);

};
