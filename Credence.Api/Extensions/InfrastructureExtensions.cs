using Microsoft.EntityFrameworkCore;

using Credence.Infrastructure.Data;
using Credence.Default.ApiContext.Configurations;
using Credence.Infrastructure.UserContext.UseCases.Abstractions;
using Credence.Application.UserContext.UseCases.Get;
using Credence.Infrastructure.UserContext.UseCases.Validations;



namespace Credence.Api.Extensions;

public static class InfrastructureExtensions
{
    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<CredenceDbContext>(x => x
        .UseMySql(
            ApiSettings.ConnectionString,
            ServerVersion.AutoDetect(ApiSettings.ConnectionString),
            mig => mig.MigrationsAssembly(typeof(CredenceDbContext).Assembly.FullName)));
    }
    public static void AddRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IUserRepository, UserRepository>();
        
    }
    public static void AddInfraValidations(this WebApplicationBuilder builder) => 
                                            builder.Services.AddTransient<IValidation, Validation>();
    
}

