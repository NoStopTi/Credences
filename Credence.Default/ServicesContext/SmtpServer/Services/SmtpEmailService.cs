using System.Net;
using System.Net.Mail;
using Credence.Default.ServicesContext.SmtpServer.Models;
using Microsoft.Extensions.Options;

namespace Credence.Default.ServicesContext.SmtpServer.Services;

public sealed class SmtpEmailService : ISmtpEmailService, IDisposable
{
    private readonly EmailServiceConfiguration _config;

    private SmtpClient? _smtpClient;
    private bool _disposed;



    public SmtpEmailService(IOptions<EmailServiceConfiguration> config)
    {
        _config = config.Value;
    }

    public string GetFrom() => _config.DefaultFrom;

    private SmtpClient CreateSmtpClient() => new SmtpClient("smtp.kinghost.net")
    {
        // Port = 587,
        // Credentials = new NetworkCredential("noreplay@nostopti.com.br", "Nsti@2026"),
        // EnableSsl = false,
        // Timeout = 30 * 1000
        Port = _config.Port,
        Credentials = new NetworkCredential(_config.UserName, _config.Password),
        EnableSsl = _config.UseSsl,
        Timeout = _config.TimeoutSeconds * 1000
    };
    public async Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default)
    {
        using var mailMessage = CreateMailMessage(message);

        await SendMailAsync(mailMessage, cancellationToken);
    }
    private MailMessage CreateMailMessage(EmailMessage message)
    {
        var from = message.From ?? _config.DefaultFrom;

        string first = message.To.Split(';')[0];

        var mailMessage = new MailMessage(from, first, message.Subject, message.Body)
        {
            IsBodyHtml = message.IsBodyHtml,
        };

        if (!string.IsNullOrWhiteSpace(message.Attachments))
        {
            HandlerAttachments(message.Attachments ?? string.Empty).ForEach(x =>
            {
                mailMessage.Attachments.Add(x);
            });
        }

        var emails = HasCopies(message.To);

        emails.ForEach(x => mailMessage.CC.Add(x));

        return mailMessage;
    }
    private List<Attachment> HandlerAttachments(string paths)
    {
        var attachments = new List<Attachment>();

        string[] attach = paths.Split(';');

        foreach (string path in attach)
            if (File.Exists(path.Trim()))
                attachments.Add(new Attachment(path.Trim()));

        return attachments;

    }
    private async Task SendMailAsync(MailMessage message, CancellationToken cancellationToken)
    {

        _smtpClient = CreateSmtpClient();

        try
        {
            await _smtpClient.SendMailAsync(message, cancellationToken);
        }
        catch (SmtpFailedRecipientException ex) when (ex.StatusCode == SmtpStatusCode.MailboxBusy)
        {
            Console.WriteLine(@$"{message.To}Exception: {ex}");
        }
        catch (SmtpFailedRecipientException ex)
        {
            Console.WriteLine($"Falha no envio para destinatário:{message.To} Exception: {ex}");

        }
        catch (SmtpException ex)
        {
            Console.WriteLine($"Erro SMTP ao enviar mensagem:{message.To} Exception: {ex}");

        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro inesperado ao enviar email:{message.To} Exception: {ex}");
        }
    }
    private List<string> HasCopies(string emails)
    {
        var copies = new List<string>();


        string[] splitedEmails = emails.Split(';');

        if (splitedEmails.Length > 0)
        {
            foreach (string email in splitedEmails)
            {
                if (!string.IsNullOrWhiteSpace(email))
                    copies.Add(email.Trim());
            }
        }
        else
            copies.Add(emails);

        return copies;
    }



    public void Dispose()
    {
        if (!_disposed)
        {
            _smtpClient?.Dispose();
            _disposed = true;
        }

        _disposed = true;
    }

}
