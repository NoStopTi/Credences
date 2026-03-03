using System.Diagnostics.CodeAnalysis;

namespace Credence.Default.ServicesContext.SmtpServer.Models;

public class EmailMessage
{

    [SetsRequiredMembers]
    public EmailMessage(string to,
                        string from,
                        string subject,
                        string body,
                        bool isBodyHtml,
                        string? attachments
                        )
    {
        this.To = to;
        this.From = from;
        this.Subject = subject;
        this.Body = body;
        this.IsBodyHtml = isBodyHtml;
        this.Attachments = attachments;
    }

    public string To { get; private set; } = string.Empty;
    public string Subject { get; private set; } = string.Empty;
    public string Body { get; private set; } = string.Empty;
    public string From { get; private set; }
    public bool IsBodyHtml { get; private set; } = true;
    public string? Attachments { get; private set; }

}