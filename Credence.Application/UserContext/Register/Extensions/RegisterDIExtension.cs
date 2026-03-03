
using Credence.Application.SharedContext.Contracts.Register;
using Credence.Application.UserContext.Register.UseCases;
using Credence.Application.UserContext.Register.UseCases.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Credence.Application.UserContext.UseCases.Register.Extensions;

public static class RegisterDIExtension
{
    public static void AddRegisterServices(this WebApplicationBuilder builder)
    {
        
         builder
        .Services
        .AddTransient<IRegisterHandler, RegisterHandler>();

        builder
       .Services
       .AddTransient<IRegisterService, RegisterService>();
    }
}