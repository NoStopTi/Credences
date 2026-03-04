using Credence.Application.AuthContext.UseCases.Services.Jwt.Enums;
using Credence.Application.SharedContext.Contracts.Authorization.Jwt;
using Credence.Application.SharedContext.Contracts.Authorization.Role;
using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Application.SharedContext.Contracts.GetUser;
using Credence.Application.SharedContext.Contracts.Login;
using Credence.Application.SharedContext.Contracts.Passwords;
using Credence.Application.SharedContext.Contracts.Validations;
using Credence.Application.SharedContext.Responses;
using Credence.Application.UserContext.Exceptions;
using Credence.Application.UserContext.Login.UseCases.Enums;
using Credence.Application.UserContext.Login.UseCases.Requests;
using Credence.Application.UserContext.Login.UseCases.Responses;
using Credence.Application.UserContext.UseCases.Login.Contracts;
using Credence.Application.UserContext.UseCases.Validations;
using Credence.Default.Abstractions;
using Credence.Default.Constants.EmailContext;
using Credence.Default.Constants.JwtContext;
using Credence.Default.Constants.PasswordContext;
using Credence.Default.Constants.UserContext;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.UserContext.Entities;
using Credence.Domain.UserContext.ValueObjects;
using Flunt.Notifications;
using Flunt.Validations;

using Microsoft.AspNetCore.Mvc;

namespace Credence.Application.UserContext.Login.UseCases;

public class LoginHandler(
                          [FromServices] IUserCanAuthenticateValidation canAuthenticate,
                          [FromServices] IUserValidations _userValidations,
                          [FromServices] IGetService userGet,
                          [FromServices] ISetLastLogin userWrite,
                          [FromServices] IPasswordService passwordServices,
                          [FromServices] IConfirmationService sendConfirmationService,
                          [FromServices] ILockedUserNotificationService sendNotification,
                          [FromServices] ITwoFactorTokenService sendToken2Fa,
                          [FromServices] IJwtWriteTokenServices jwtServices,
                          [FromServices] IRolesServices rolesServices,
                          [FromServices] ITimeProviderServices timeProviderService
                          ) : Notifiable<Notification>, ILoginHandler
{
    public async Task<Response<LoginResponse>> Login(LoginUserRequest request)
    {
        RequestValidate(request.Email, request.Password, LoginConst.NotePath_07);

        var getUser = await userGet.EnsureNameOrEmailIsUniqueAsync(request.Email, LoginConst.NotePath_04) ?? null!;

        await IsEmailConfirm(getUser.User ?? null!);

        var isValidPwd = await passwordServices.PasswordSignInAsync(getUser.User ?? null!,
                                                                   request.Password,
                                                                   request.RememberMe,
                                                                   lockoutOnFailure: true);

        var isEnable2FA = await RequiresTwoFactor(getUser.User ?? null!, isValidPwd);

        CanAuthenticate(isValidPwd.Succeeded, isEnable2FA, getUser.User ?? null!);

        _userValidations.IsValidForLogin(getUser.User ?? null!, LoginConst.NotePath_01);

        await userWrite.SetLastLoginAsync(getUser.User ?? null!);

        var expires = TokenExpiresBuilder(isEnable2FA, request.TimeZone);

        string tokenJwt = await jwtServices.GenerateJwtToken(getUser.User ?? null!, expires, TokenType(isEnable2FA, isValidPwd.Succeeded));

        var getRoles = await rolesServices.GetRolesAsync(getUser.User ?? null!);

        return (isValidPwd.Succeeded || isEnable2FA) ? new LoginResponse().Response(isValidPwd.Succeeded,
                                                                                    isEnable2FA,
                                                                                    expires,
                                                                                    tokenJwt,
                                                                                    getUser?.User!.Email ?? string.Empty,
                                                                                    getUser!.User!.Id,
                                                                                    isEnable2FA ?
                                                                                    [RoleConst.TwoFactorRolePendingName] : getRoles.ToList(),
                                                                                    Notifications.ToList()) : new LoginResponse().Response(Notifications.ToList());
    }
    private ETokenType TokenType(bool isEnable2FA, bool isAuthenticated)
    {

        if (isEnable2FA is false && isAuthenticated is false) return ETokenType.Unauthorized;


        return isEnable2FA ? ETokenType.TwoFactorPending : ETokenType.Authenticated;

        // if (isEnable2FA && !isInTwoFactorRole)
        // {
        //     await rolesServices.AddUserRoleAsync(user ?? null!, Guid.Parse(RoleConst.TwoFactorPendingIdGuid), Guid.Parse(CompanyConst.CompanyId));
        //     return ETokenType.TwoFactorPending;
        // }

        // if (isEnable2FA && !isInAdminRole)
        // {
        //     await rolesServices.AddUserRoleAsync(user ?? null!, Guid.Parse(RoleConst.AdminRoleName), Guid.Parse(CompanyConst.CompanyId));
        //     return ETokenType.Authenticated;
        // }

        // if (isEnable2FA)
        //     return ETokenType.TwoFactorPending;

        // if (!isEnable2FA && isInAdminRole)
        //     return ETokenType.Authenticated;

        // return ETokenType.Unauthorized;
    }
    // private async Task<ETokenType> BuilderTokenType(User user, bool isEnable2FA)
    // {
    //     var isInTwoFactorRole = await rolesServices.IsInRoleAsync(user ?? null!, RoleConst.TwoFactorRolePendingName);
    //     var isInAdminRole = await rolesServices.IsInRoleAsync(user ?? null!, RoleConst.AdminRoleName);

    //     if (isEnable2FA && !isInTwoFactorRole)
    //     {
    //         await rolesServices.AddUserRoleAsync(user ?? null!, Guid.Parse(RoleConst.TwoFactorPendingIdGuid), Guid.Parse(CompanyConst.CompanyId));
    //         return ETokenType.TwoFactorPending;
    //     }

    //     if (isEnable2FA && !isInAdminRole)
    //     {
    //         await rolesServices.AddUserRoleAsync(user ?? null!, Guid.Parse(RoleConst.AdminRoleName), Guid.Parse(CompanyConst.CompanyId));
    //         return ETokenType.Authenticated;
    //     }

    //     if (isEnable2FA)
    //         return ETokenType.TwoFactorPending;

    //     if (!isEnable2FA && isInAdminRole)
    //         return ETokenType.Authenticated;

    //     return ETokenType.Unauthorized;
    // }
    private DateTime TokenExpiresBuilder(bool twoFactor, string timeZone)
    {
        var tz = timeProviderService.GetTimeZoneById(timeZone);

        var localTimeZone = timeProviderService.ConvertTime(DateTimeOffset.UtcNow, tz);

        var expires = localTimeZone.UtcDateTime;
        var result = localTimeZone.UtcDateTime;

        if (!twoFactor)
            result = expires.AddHours(JwtConst.LoginExpiresHours);

        if (twoFactor)
            result = expires.AddMinutes(JwtConst.CompleProcessLifeTimeToken);

        return result;
    }
    private void RequestValidate(string email, string pass, string source)
    {
        var emailChecked = new Email(email);
        emailChecked.Validate($"{LoginConst.NotePath_05} - {source}");

        var passwordChecked = new Password(pass);
        passwordChecked.Validate($"{LoginConst.NotePath_06} - {source}");

        if (!IsValid)
            throw new LoginExceptions(PasswordConst.PwdOrUserInvalid);
    }
    private async void CanAuthenticate(bool pwdCheckResult, bool isEnable2FA, User user)
    {
        var isLockedOut = await canAuthenticate.IsLockedOutAsync(user ?? null!);

        if (pwdCheckResult && !isLockedOut)
        {
            var result = canAuthenticate.CheckUserLockoutType(isLockedOut);
            SelectNotifications(isEnable2FA, pwdCheckResult, result);

            await NotificationOnUserLocked(result.LockoutType,
                                                   result.RemainingLockoutTime
                                                   ??
                                                   TimeSpan.Zero,
                                                   user ?? null!);
        }
    }
    private async Task NotificationOnUserLocked(ELockoutType type, TimeSpan? remaremaining, User user)
    {

        await (type switch
        {
            ELockoutType.Indefinite =>
            sendNotification.UserLockedNotificationAsync(
                                                            user?.Name?.DisplayName
                                                            ?? UserConst.None,
                                                            user?.Email ?? string.Empty
                                                            ),
            ELockoutType.Temporarily =>
            sendNotification.UserTemporarilyLockedNotificationAsync(
                                                            user?.Name?.DisplayName
                                                            ?? UserConst.None,
                                                            user?.Email ?? string.Empty,
                                                            remaremaining?.TotalHours.ToString() ?? string.Empty),
            ELockoutType.None => Task.CompletedTask,

            _ => Task.CompletedTask

        });


        if (type == ELockoutType.Indefinite)
            throw new LoginExceptions(UserConst.AccountHasBeenLocked);

        if (type == ELockoutType.Temporarily)
            throw new LoginExceptions(UserConst.AccountTemporarilyLocked);

    }
    private async Task<bool> RequiresTwoFactor(User user, Microsoft.AspNetCore.Identity.SignInResult pwdCheckResult, string provider = JwtConst.GenerateTwoFactorTokenAsync)
    {
        if (pwdCheckResult.RequiresTwoFactor)
        {
            var displayName = user.Email?.Split('@')[0];

            var empty = string.Empty;

            var urlToken = await sendToken2Fa.BuildToken(user, provider);

            await sendToken2Fa.SendTwoFactorTokenAsync(urlToken, displayName ?? empty, user.Email ?? empty);

            return true;
        }

        if (pwdCheckResult.RequiresTwoFactor || pwdCheckResult.Succeeded)
            await passwordServices.ResetAccessFailedCountAsync(user);

        return false;
    }
    private async Task IsEmailConfirm(User user)
    {
        if (user != null && !user.EmailConfirmed)
        {
            var urlToken = await sendConfirmationService.BuildToken(user);

            await sendConfirmationService.SendEmailConfirmationAsync(urlToken,
                                        user.Name?.DisplayName!,
                                        user.Email!);

            AddNotification(EmailConst.NotePath_01, EmailConst.EmailNotConfirmed);
            await Task.CompletedTask;
        }
        else
            await Task.CompletedTask;
    }
    private void SelectNotifications(bool isEnabled2FA, bool isPasswordValid, CanAuthValidationResponse canAuthValidationResult)
    {
        if (isEnabled2FA)
        {

            AddNotifications(new Contract<bool>().IsTrue(canAuthValidationResult.LockoutType == ELockoutType.None,
                                                         $@"{UserConst.AccountHasBeenLocked}: 
                                                            {UserConst.AccountLockoutType} 
                                                            {canAuthValidationResult.LockoutType}
                                                            {UserConst.LoginErroPlaceNotification}"));
        }
        else
        {
            AddNotifications(new Contract<bool>().IsTrue(isPasswordValid, PasswordConst.PwdOrUserInvalid)
                                                 .IsTrue(canAuthValidationResult.LockoutType == ELockoutType.None,
                                                         $@"{UserConst.AccountHasBeenLocked}: 
                                                            {UserConst.AccountLockoutType} 
                                                            {canAuthValidationResult.LockoutType}
                                                            {UserConst.LoginErroPlaceNotification}"));
        }

    }

}