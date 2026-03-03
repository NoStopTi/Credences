using Credence.Application.SharedContext.Contracts;
using Credence.Application.SharedContext.Exceptions;
using Credence.Default.Constants.EmailContext;
using Credence.Default.Constants.JwtContext;
using Credence.Default.Constants.PasswordContext;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;

namespace Credence.Application.SharedContext.Services.Identity;

public class IdentityTokensServices : IIdentityTokensServices
{
    private readonly UserManager<User> _userManager;
    private readonly LinkGenerator _linkGenerator;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private HttpContext _httpContext =>
        _httpContextAccessor.HttpContext
        ?? throw new IdentityTokensException(IdentityConst.UnableGenerateConfirmationToken);

    public IdentityTokensServices(
        UserManager<User> userManager,
        LinkGenerator linkGenerator,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _linkGenerator = linkGenerator;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<string> GenerateUrlTokenEmailConfirmationAsync(User user)
    {
        string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        var url = _linkGenerator.GetUriByName(_httpContext ?? null!, EmailConst.ConfirmEmail,
        new
        {
            token = token.Encoded_UTF8_Base64(),
            email = user.Email
        }
        );

        return url ?? throw new IdentityTokensException(IdentityConst.UnableGenerateConfirmationToken);
    }

    public async Task<string> GenerateTwoFactorTokenAsync(User user, string provider = JwtConst.GenerateTwoFactorTokenAsync)
    {
        string token = await _userManager.GenerateTwoFactorTokenAsync(user, provider);

        string urlToken = await GenerateUrlLinkWithToken2FA(token, user.Email ?? string.Empty, TwoFactorConst.GenerateTokenSendEmailRoute)
        ?? throw new IdentityTokensException(IdentityConst.UnableGenerateTwoFactorToken);

        return urlToken;
    }
    private async Task<string?> GenerateUrlLinkWithToken2FA(string rawToken, string email, string routes)
    {
        return await Task.FromResult(_linkGenerator.GetUriByName(_httpContext ?? null!, routes,
        new { token = rawToken, email }));
    }
    public async Task<string> GenerateUrlTokenPasswordReset(User user)
    {
        var rawToken = await _userManager.GeneratePasswordResetTokenAsync(user);

        var url = _linkGenerator.GetUriByName(_httpContext ?? null!, PasswordConst.PasswordReset,
            new
            {
                token = rawToken.Encoded_UTF8_Base64(),
                email = user.Email,
                userName = user.UserName
            }) ?? throw new IdentityTokensException(PasswordConst.PwdResetToken);

        return url;
    }
}
