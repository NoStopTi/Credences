using Credence.Application.SharedContext.Constants.EmailNotificationsSender;
using Credence.Application.SharedContext.Contracts;
using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Application.SharedContext.Contracts.Identity;
using Credence.Default.ServicesContext.SmtpServer.Models;
using Credence.Default.ServicesContext.SmtpServer.Services;
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Services.EmailNotificationsSender;

public class PasswordResetTokenService(
                                      ISmtpEmailService emailService,
                                      IIdentityTokensServices identityTokensServices
                                     ) :IPasswordResetTokenService,IBuildTokenService
{

    public async Task SendEmailResetTokenAsync(string tokenUrl, string displayName, string to)
    {
        string subject = MudancaSenhaMsg.Subject;
        string body = MudancaSenhaMsg.PasswordReset(displayName, MudancaSenhaMsg.FrontendUrl, tokenUrl, MudancaSenhaMsg.BackendUrl);
        string from = emailService.GetFrom();

        await emailService.SendAsync(new EmailMessage(to, from, subject, body, true, string.Empty), CancellationToken.None);
    }
    public async Task<string> BuildToken(User user)
    {
        return await identityTokensServices.GenerateUrlTokenPasswordReset(user);
    }
}
