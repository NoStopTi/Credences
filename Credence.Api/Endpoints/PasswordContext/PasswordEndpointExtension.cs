using Credence.Api.Endpoints.PasswordContext.Routes;
using Credence.Default.Constants.PasswordContext;

namespace Credence.Api.Endpoints.PasswordContext;

public static class PasswordEndpointExtension
{
    public static void EnpointsPasswordMap(this WebApplication app)
    {                
        app.MapGroup(PasswordConst.GroupRoute)
            .WithTags(PasswordConst.GroupRouteTag)
            .MapEndpoint<ForgotPasswordEndpoint>()
            .MapEndpoint<ResetPasswordEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder routerBuilder)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(routerBuilder);

        return routerBuilder;
    }
 
}