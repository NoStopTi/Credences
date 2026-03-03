
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Credence.Application.SharedContext.Contracts.EmailNotifications;
using Credence.Application.SharedContext.Services.EmailNotificationsSender;
using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Application.UserContext.TwoFactor.UseCases.Services;

namespace Credence.Application.UserContext.TwoFactor.Extensions;


public static class TwoFactorDIExtension
{
  public static void AddTwoFactorServices(this WebApplicationBuilder builder)
  {
       builder
        .Services
             .AddTransient<ISetupTwoFactorService, SetupTwoFactorService>();
   
       builder
        .Services
             .AddTransient<ITwoFactorTokenService, TwoFactorTokenService>();

     builder
        .Services
             .AddTransient<ITwoFactorHandler, TwoFactorHandler>();

      builder
        .Services
             .AddTransient<IAuthenticateUser, VerifyCodeService>();

      builder
        .Services
             .AddTransient<IVerifyCodeService, VerifyCodeService>();

      builder
        .Services
             .AddTransient<IVerifyCodeService, TwoFactorControlService>();
      builder
        .Services
             .AddTransient<IEnableDisableService, TwoFactorControlService>();

      builder
        .Services
             .AddTransient<IOnOffCodeService, OnOffCodeService>();

      builder
        .Services
             .AddTransient<IIsEnabledService, GetStatusService>();

  }
}

