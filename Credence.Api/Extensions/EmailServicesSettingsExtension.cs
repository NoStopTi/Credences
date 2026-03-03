using Credence.Default.ServicesContext.SmtpServer.Models;
using Credence.Default.ServicesContext.SmtpServer.Services;
using Credence.Default.ServicesContext.SmtpServer.Validators;

namespace Credence.Api.Extensions;

public static class EmailServicesSettingsExtension
{
    public static void AddEmailService(this WebApplicationBuilder builder)
    {
        var pathConfig = builder.Configuration.GetSection(EmailServiceConfiguration.SectionName);
        builder.Services.Configure<EmailServiceConfiguration>(pathConfig);
                
        builder.Services.AddSingleton<IEmailServiceValidator, EmailServiceValidator>();
        builder.Services.AddTransient<ISmtpEmailService, SmtpEmailService>();
    }
    public static IServiceCollection AddEmailService(this IServiceCollection services, Action<EmailServiceConfiguration> configure)
    {
        services.Configure(configure);

        services.AddSingleton<IEmailServiceValidator, EmailServiceValidator>();
        services.AddTransient<ISmtpEmailService, SmtpEmailService>();

        return services;
    }



}