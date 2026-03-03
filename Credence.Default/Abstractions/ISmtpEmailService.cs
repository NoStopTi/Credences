using Credence.Default.ServicesContext.SmtpServer.Models;

namespace Credence.Default.ServicesContext.SmtpServer.Services;

public interface ISmtpEmailService
{
    Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default);
    string GetFrom();
    void Dispose();
}