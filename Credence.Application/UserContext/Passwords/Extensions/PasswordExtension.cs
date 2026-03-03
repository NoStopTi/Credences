
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Credence.Application.SharedContext.Contracts.Passwords;
using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Application.SharedContext.Services.EmailNotificationsSender;
using Credence.Application.UserContext.Passwords.UseCases.Services;

namespace Credence.Application.UserContext.Passwords.UseCases;


public static class PasswordDIExtension
{
    public static void AddPasswordServices(this WebApplicationBuilder builder)
    {
        builder
            .Services
                .AddTransient<IForgotHandler, ForgotHandler>();
        builder
            .Services
                .AddTransient<IResetHandler, ResetHandler>();
        builder
            .Services
                .AddTransient<IPasswordService, PasswordService>();
        builder
            .Services
                .AddTransient<IPasswordResetTokenService, PasswordResetTokenService>();
    }
}

