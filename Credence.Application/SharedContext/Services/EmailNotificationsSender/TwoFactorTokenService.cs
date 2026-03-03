
using Credence.Application.SharedContext.Constants.EmailNotificationsSender;
using Credence.Application.SharedContext.Contracts;
using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Default.ServicesContext.SmtpServer.Models;
using Credence.Default.ServicesContext.SmtpServer.Services;
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Services.EmailNotificationsSender;

public class TwoFactorTokenService(
                                        ISmtpEmailService emailService,
                                        IIdentityTokensServices identityTokensServices
                                     ) : ITwoFactorTokenService
{

    public async Task SendTwoFactorTokenAsync(string tokenUrl, string displayName, string to)
    {
        string subject = AutenticacaoDoisFatoresMsg.Subject;
        string body = AutenticacaoDoisFatoresMsg.TwoFactorAuthentication(tokenUrl);
        string from = emailService.GetFrom();

        await emailService.SendAsync(new EmailMessage(to, from, subject, body, true, string.Empty), CancellationToken.None);
    }
    
    public async Task<string> BuildToken(User user, string provider)=>
        await identityTokensServices.GenerateTwoFactorTokenAsync(user, provider);

}
