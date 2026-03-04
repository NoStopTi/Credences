using Credence.Application.SharedContext.Responses;
using Credence.Default.Constants.EmailContext;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;

using Flunt.Notifications;
using Microsoft.AspNetCore.Http;


namespace Credence.Application.UserContext.Login.UseCases.Responses;

public class LoginResponse
{
    public LoginResponse() { }
    private LoginResponse(
                         bool authenticated,
                         bool isEnable2FA,
                         DateTime expires,
                         string token,
                         string email,
                         Guid userId,
                         List<string> roles,
                         List<Notification> notifications
                         )
    {
        Authenticated = authenticated;
        IsEnable2FA = isEnable2FA;
        Expires = expires;
        Token = token;
        Email = email;
        UserId = userId;
        RolesListHandler(roles);
    }
    public bool Authenticated { get; private set; }
    public bool IsEnable2FA { get; private set; } = false;
    public DateTime Expires { get; private set; }
    public string Token { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public Guid UserId { get; private set; }
    public List<string>? Roles { get; private set; }

    private void RolesListHandler(List<string>? roles)
    {
        if (roles?.Count > 0)
        {
            Roles = [];
            Roles!.AddRange(roles);
        }
        else
            Roles = [];
    }
    public Response<LoginResponse> Response(IList<Notification> notifications) => notifications.Any()
                                            ? new Response<LoginResponse>(LoginFailed([.. notifications]), StatusCodes.Status400BadRequest)
                                            : new Response<LoginResponse>();
    public Response<LoginResponse> Response(bool isLoginValid, IList<Notification> notifications) => isLoginValid
                                            ? new Response<LoginResponse>(LoginFailed([.. notifications]), StatusCodes.Status400BadRequest)
                                            : new Response<LoginResponse>();
    public Response<LoginResponse> Response(bool authenticated,
                                                bool isEnable2FA,
                                                DateTime expires,
                                                string token,
                                                string email,
                                                Guid userId,
                                                List<string> roles,
                                                List<Notification> notifications) =>
                                                                    new Response<LoginResponse>(LoginSucceeded(authenticated,
                                                                    isEnable2FA,
                                                                    expires,
                                                                    token,
                                                                    email,
                                                                    userId,
                                                                    roles,
                                                                    notifications), StatusCodes.Status200OK, $"2FA is {isEnable2FA}");
    private static LoginResponse LoginSucceeded(bool authenticated,
                                                 bool isEnable2FA,
                                                 DateTime expires,
                                                 string token,
                                                 string email,
                                                 Guid userId,
                                                 List<string> roles,
                                                 List<Notification> notifications)
    {
        return (authenticated || isEnable2FA) ? new LoginResponse(authenticated,
                                                 isEnable2FA,
                                                 expires,
                                                 token,
                                                 email,
                                                 userId,
                                                 roles,
                                                 notifications)
                              : new LoginResponse(false,
                                                  false,
                                                  DateTime.MinValue,
                                                  IdentityConst.UnableGenerateToken,
                                                  EmailConst.InvalidEmail,
                                                  Guid.Empty,
                                                  ["InvalidRole"],
                                                  []);
    }
    private static LoginResponse LoginFailed(List<Notification> notifications)
    {
        return new LoginResponse(false,
                                 false,
                                 DateTime.MinValue,
                                 IdentityConst.UnableGenerateToken,
                                 EmailConst.InvalidEmail,
                                 Guid.Empty,
                                 ["Invalid"],
                                 notifications);
    }

}