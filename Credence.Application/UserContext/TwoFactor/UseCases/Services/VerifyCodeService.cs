using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.UserContext.TwoFactor.UseCases.Services;


public class VerifyCodeService(UserManager<User> userManager, SignInManager<User> signInManager) : IVerifyCodeService, IAuthenticateUser
{
        public async Task<bool> IsValidCodeAsync(User user, string provider, string code) => await userManager.VerifyTwoFactorTokenAsync(user, provider, code);
        public async Task SignInAsync(User user, bool rememberMe) => await signInManager.SignInAsync(user, rememberMe);
}