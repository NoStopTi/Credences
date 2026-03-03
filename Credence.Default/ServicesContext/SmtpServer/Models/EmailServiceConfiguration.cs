
namespace Credence.Default.ServicesContext.SmtpServer.Models;

public sealed class EmailServiceConfiguration
{

    public EmailServiceConfiguration()
    {
       
    }
    public EmailServiceConfiguration(string smtpServer, int port, bool useSsl, string userName, string password)
    {
        SmtpServer = smtpServer;
        Port = port;
        UseSsl = useSsl;
        UserName = userName;
        Password = password;
    }
    public const string SectionName = "Email";

    public string? SmtpServer { get; set; }

    public int Port { get; set; }

    public bool UseSsl { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string DefaultFrom { get; set; } = string.Empty;

    public int TimeoutSeconds { get; private set; } = 30;

    public void SetDefaultFrom(string defaultFrom)
    {
        DefaultFrom = defaultFrom;
    }
    public void SetTimeoutSeconds(int timeoutSeconds)
    {
        TimeoutSeconds = timeoutSeconds;
    }

}
