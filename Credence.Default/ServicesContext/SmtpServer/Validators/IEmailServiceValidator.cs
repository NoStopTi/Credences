

using Credence.Default.ServicesContext.SmtpServer.Models;

namespace Credence.Default.ServicesContext.SmtpServer.Validators;

public interface IEmailServiceValidator
{
    bool IsValidEmail(string email);
    void ValidateMessage(EmailMessage message);
}