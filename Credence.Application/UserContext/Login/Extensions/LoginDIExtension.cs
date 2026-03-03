
using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Application.SharedContext.Contracts.Login;
using Credence.Application.SharedContext.Services.EmailNotificationsSender;
using Credence.Application.UserContext.Login.UseCases;
using Credence.Application.UserContext.Login.UseCases.Services;
using Credence.Application.UserContext.UseCases.Login.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Credence.Application.UserContext.Login.Extensions;


public static class LoginDIExtension
{
    public static void AddLoginServices(this WebApplicationBuilder builder)
    {
        builder
            .Services
                .AddTransient<ILoginHandler, LoginHandler>();
        builder
            .Services
                .AddTransient<ISetLastLogin, LastLoginService>();
        builder
            .Services
                .AddTransient<ILockedUserNotificationService, LockedUserNotificationService>();
    }
}