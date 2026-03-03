using Credence.Application.SharedContext.Constants.EmailNotificationsSender;
using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Default.ServicesContext.SmtpServer.Models;
using Credence.Default.ServicesContext.SmtpServer.Services;
using Microsoft.AspNetCore.Mvc;


namespace Credence.Application.SharedContext.Services.EmailNotificationsSender;

public class LockedUserNotificationService(
                                            [FromServices] ISmtpEmailService emailService
                                          ) : ILockedUserNotificationService
{

    public async Task UserLockedNotificationAsync(string displayName, string to)
    {
        string subject = ContaUsuarioBloqueada.Subject;
        string body = ContaUsuarioBloqueada.AccountPermanentlyBlockedMessage(displayName, ContaUsuarioBloqueada.FrontendUrl);
        string from = emailService.GetFrom();

        await emailService.SendAsync(new EmailMessage(to, from, subject, body, true, string.Empty), CancellationToken.None);
    }
    public async Task UserTemporarilyLockedNotificationAsync(string displayName, string to, string timeRemaining)
    {
        string subject = ContaUsuarioBloqueada.Subject;
        string body = ContaUsuarioBloqueada.AccountTemporarilyBlockedMessage(displayName, ContaUsuarioBloqueada.FrontendUrl,timeRemaining);
        string from = emailService.GetFrom();

        await emailService.SendAsync(new EmailMessage(to, from, subject, body, true, string.Empty), CancellationToken.None);
    }


}


