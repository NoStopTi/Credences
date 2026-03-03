
using Credence.Default.Abstractions;
using Credence.Default.ServicesContext.DateTimeTasks;



namespace Credence.Api.Extensions;

public static class DefaultHelpersExtensions
{

    public static void AddDefaultHelpers(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<ITimeProviderServices, TimeProviderService>();
    }
}

