using Credence.Application.UserContext.UseCases.Register.Extensions;
using Credence.Application.SalesContext.UseCases.Extensions;
using Credence.Application.UserContext.Passwords.UseCases;
using Credence.Application.UserContext.TwoFactor.Extensions;
using Credence.Application.SharedContext.Services.Identity.Extensions;
using Credence.Application.UserContext.Login.Extensions;
using Credence.Application.AuthContext.Extensions;
using Credence.Application.UserContext.EmailConfirmation.Extensions;
using Credence.Application.UserContext.UseCases.Extensions;

namespace Credence.Api.Extensions;

public static class ServicesDIExtension
{
    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder
        .Services
        .AddHttpContextAccessor();

        builder.AddLoginServices();
        builder.AddRegisterServices();
        builder.AddJwtRolesServices();
        builder.AddSalesServices();
        builder.AddPasswordServices();
        builder.AddEmailConfirmationServices();
        builder.AddTwoFactorServices();
        builder.AddIdentityServices();
        builder.AddUserServices();
    }
}

