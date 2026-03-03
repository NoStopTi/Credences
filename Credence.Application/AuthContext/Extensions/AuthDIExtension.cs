
using Credence.Application.AuthContext.Roles.UseCases;
using Credence.Application.AuthContext.UseCases.Services.Jwt.GenerateJwtUserToken;
using Credence.Application.SharedContext.Contracts.Authorization.Jwt;
using Credence.Application.SharedContext.Contracts.Authorization.Role;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Credence.Application.AuthContext.Extensions;

public static class AuthDIExtension
{
    public static void AddJwtRolesServices(this WebApplicationBuilder builder)
    {
         builder
       .Services
       .AddTransient<IJwtServices, JwtServices>();

        builder
       .Services
       .AddTransient<IRolesServices, RolesServices>();
    }
}