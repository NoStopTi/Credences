using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Credence.Application.UserContext.Contracts;
using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Application.SharedContext.Services.EmailNotificationsSender;
using Credence.Application.UserContext.EmailConfirmation.UseCases;

namespace Credence.Application.UserContext.EmailConfirmation.Extensions;

public static class EmailConfirmationDIExtension
{
    public static void AddEmailConfirmationServices(this WebApplicationBuilder builder)
    {
        builder
            .Services
                .AddTransient<IEmailConfirmationHandler, EmailConfirmationHandler>();

        builder
            .Services
                .AddTransient<IConfirmationService, ConfirmationService>();

    }
}

