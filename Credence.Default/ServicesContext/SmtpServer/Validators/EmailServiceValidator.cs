
using System.Text.RegularExpressions;
using Credence.Default.ServicesContext.SmtpServer.Models;


namespace Credence.Default.ServicesContext.SmtpServer.Validators;

public partial class EmailServiceValidator : IEmailServiceValidator
{
    public bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        return EmailRegex().IsMatch(email);
    }

    public void ValidateMessage(EmailMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        if (!IsValidEmail(message.To))
            throw new Exception($"Destinatário inválido: {message.To}");

        if (!string.IsNullOrEmpty(message.From) && !IsValidEmail(message.From))
            throw new Exception($"Remetente inválido: {message.From}");

        if (string.IsNullOrWhiteSpace(message.Subject))
            throw new Exception("Assunto não pode ser vazio");

        if (string.IsNullOrWhiteSpace(message.Body))
            throw new Exception("Corpo da mensagem não pode ser vazio");
    }

    [GeneratedRegex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
    private static partial Regex EmailRegex();
}
