
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Credence.Application.UserContext.UseCases.Services;
using Credence.Application.SharedContext.Contracts.GetUser;
using Credence.Application.SharedContext.Contracts.Validations;
using Credence.Application.UserContext.UseCases.Validations;
using Credence.Infrastructure.UserContext;

namespace Credence.Application.UserContext.UseCases.Extensions;

public static class UserDIExtension
{
    public static void AddUserServices(this WebApplicationBuilder builder)
    {
        builder
           .Services
               .AddTransient<IGetService, GetService>();
        builder
           .Services
               .AddTransient<IUserManagerService, UserManagerService>();
        builder
           .Services
               .AddTransient<IUserValidations, UserValidations>();
        builder
           .Services
               .AddTransient<IUserRoleRepository, UserRoleRepository>();

        builder
           .Services
               .AddTransient<IUserCanAuthenticateValidation, UserCanAuthenticateValidation>();
    }
}

