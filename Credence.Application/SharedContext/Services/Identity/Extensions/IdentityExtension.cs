
using Credence.Application.SharedContext.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Credence.Application.SharedContext.Services.Identity.Extensions;


public static class IdentityDIExtension
{
    public static void AddIdentityServices(this WebApplicationBuilder builder)
    {
      builder
          .Services
          .AddTransient<IIdentityTokensServices, IdentityTokensServices>();
    }
}

