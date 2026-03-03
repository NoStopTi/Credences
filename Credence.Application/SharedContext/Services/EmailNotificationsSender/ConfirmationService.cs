using Credence.Application.SharedContext.Constants.EmailNotificationsSender;
using Credence.Application.SharedContext.Contracts;
using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Default.ServicesContext.SmtpServer.Models;
using Credence.Default.ServicesContext.SmtpServer.Services;
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Services.EmailNotificationsSender;

public class ConfirmationService(
                                      ISmtpEmailService emailService,
                                      IIdentityTokensServices identityTokensServices
                                     ) : IConfirmationService
{

    public async Task SendEmailConfirmationAsync(string tokenUrl, string displayName, string to)
    {
        string subject = SejaBemVindoMsg.Subject;
        string body = SejaBemVindoMsg.SejaBemVindo(displayName, SejaBemVindoMsg.FrontendUrl, tokenUrl, SejaBemVindoMsg.BackendUrl);
        string from = emailService.GetFrom();

        await emailService.SendAsync(new EmailMessage(to, from, subject, body, true, string.Empty), CancellationToken.None);
    }
    public async Task<string> BuildToken(User user)
    {
        return await identityTokensServices
                    .GenerateUrlTokenEmailConfirmationAsync(user);
    }
}
