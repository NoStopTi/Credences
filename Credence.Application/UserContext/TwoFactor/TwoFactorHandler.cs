
using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Application.SharedContext.Contracts.Validations;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;
using Credence.Default.Constants.JwtContext;
using Credence.Application.UserContext.TwoFactor.UseCases.Requests;
using Credence.Application.UserContext.TwoFactor.UseCases.Responses;
using Credence.Application.SharedContext.Contracts.Authorization.Jwt;
using Credence.Application.SharedContext.Contracts.Authorization.Role;
using Flunt.Notifications;
using Credence.Default.Abstractions;
using Credence.Application.SharedContext.Contracts.GetUser;
using Flunt.Validations;
using Credence.Default.DomainContext.Entities.Constants.SharedContext;
using Credence.Default.Constants.PasswordContext;
using Credence.Application.SharedContext.Responses;
using Credence.Application.UserContext.Login.UseCases.Responses;
using Credence.Application.AuthContext.UseCases.Services.Jwt.Enums;
using Credence.Application.UserContext.Exceptions;

namespace Credence.Application.UserContext.TwoFactor;


public class TwoFactorHandler(
                               [FromServices] IGetService get,
                               [FromServices] IUserManagerService userManager,
                               [FromServices] IHttpContextAccessor httpContextAccessor,
                               [FromServices] IOnOffCodeService toggleOnOffCodeViaEmailService,
                               [FromServices] IUserCanAuthenticateValidation userCanAuthenticate,
                               [FromServices] ISetupTwoFactorService setupTwoFactorService,
                               [FromServices] IVerifyCodeService verifyCodeService,
                               [FromServices] IAuthenticateUser authenticateUser,
                               [FromServices] IJwtWriteTokenServices jwtServices,
                               [FromServices] IJwtValidateTokenServices jwtValidateTokenServices,
                               [FromServices] IRolesServices rolesServices,
                               [FromServices] IEnableDisableService enableDisableService,
                               [FromServices] ITimeProviderServices timeProviderService
                              ) : Notifiable<Notification>, ITwoFactorHandler
{
    public async Task<Response<OnOffCodeViaEmailResponse>> OnOffCodeViaEmail(OnOffCodeViaEmailRequest request)
    {
        if (!request.IsValid)
            new OnOffCodeViaEmailResponse().BuilderOnOffCodeViaEmailResponse(request.OnOff, request.Notifications.ToList());

        var getUser = await get.GetByEmail(request.Email, TwoFactorConst.NotePath_01);

        var notifications = await userCanAuthenticate.Validate(getUser!.User ?? null!);

        var result = await toggleOnOffCodeViaEmailService.OnOffCodeViaEmail(getUser.User ?? null!, request.OnOff);

        return new OnOffCodeViaEmailResponse().BuilderOnOffCodeViaEmailResponse(result ? request.OnOff : result, notifications.Count > 0 ? notifications.ToList() : []);
    }
    public async Task<Response<WithAppSetupResponse>> SetupTwoFactor()
    {
        var user = await GetUserAutenticated();

        return await setupTwoFactorService.AppVerifySetupTwoFactor(user ?? null!);
    }
    public async Task<Response<LoginResponse>> VerifyCodeAsync(VerifyTwoFactorRequest request)
    {
        var claimsPrincipal = jwtValidateTokenServices.ExtractClaimsPrincipal(request.Token);

        var userEmail = jwtValidateTokenServices.ExtractEmailFromPrincipalClaims(claimsPrincipal);

        var user = await userManager.UserManager().FindByEmailAsync(userEmail) ?? null!;

        return await IsCodeValid(user, request.Provider, request.Code) ? await Authenticated(user, rememberMe: true) :

        new LoginResponse().Response(Notifications.ToList());
    }
    private async Task<Response<LoginResponse>> Authenticated(User user, bool rememberMe, string timeZone = GlobalConst.PtBr_SP)
    {
        await authenticateUser.SignInAsync(user, rememberMe);

        if (user.PasswordExpire is not null)
        {
            var pwdIsExpires = user.PasswordExpire!.IsExpired(DateTime.UtcNow);
            AddNotifications(new Contract<bool>().IsTrue(pwdIsExpires, PasswordConst.PwdHasExpiresMsg));
        }

        var expires = TokenExpiresBuilder(timeZone);

        string token = await jwtServices.GenerateJwtToken(user, expires, ETokenType.Authenticated);

        var roles = await rolesServices.GetRolesAsync(user);

        return new LoginResponse().Response(true,
                                             true,
                                             expires,
                                             token,
                                             user.Email ?? string.Empty,
                                             user.Id,
                                             roles.ToList(),
                                             Notifications.Count > 0 ? Notifications.ToList() : []);
    }
    private DateTime TokenExpiresBuilder(string timeZone)
    {
        var tz = timeProviderService.GetTimeZoneById(timeZone);

        var localTimeZone = timeProviderService.ConvertTime(DateTimeOffset.UtcNow, tz);

        var expires = localTimeZone.UtcDateTime;

        var results = expires.AddMinutes(JwtConst.CompleProcessLifeTimeToken);

        return results;
    }
    public async Task<Response<EnableDisableResponse>> EnableDisableAsync(VerifyCodeEnableDisableRequest request)
    {

        var user = await GetUserAutenticated();

        return await IsCodeValid(user, request.Provider ?? string.Empty, request.Code)
                                                                       ?
                                                                       await enableDisableService.EnableDisableAsync(user, request.ChangeState)
                                                                       :
                                                                       throw new TwoFactorException(TwoFactorConst.CodeIsInvalidError);
    }
    private async Task<bool> IsCodeValid(User user, string provider, string code) =>
                                                                                await verifyCodeService.IsValidCodeAsync(user, provider ?? string.Empty, code);
    private async Task<User> GetUserAutenticated()
    {
        var userPrincipalClims = httpContextAccessor?.HttpContext?.User;

        var userMgmt = userManager.UserManager();

        var user = await userMgmt.GetUserAsync(userPrincipalClims ?? null!);

        await userCanAuthenticate.Validate(user ?? null!);

        return user ?? null!;
    }
}