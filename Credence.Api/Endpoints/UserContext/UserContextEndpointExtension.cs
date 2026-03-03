
using  Credence.Api.Endpoints.UserContext.Routes;
using Credence.Default.Constants.UserContext;

namespace Credence.Api.Endpoints.UserContext;

public static class UserContextEndpointExtension
{
    public static void EnpointsUserMap(this WebApplication app)
    {                
        app.MapGroup(UserConst.GroupRoute)
            .WithTags(UserConst.GroupRouteTag)
            .MapEndpoint<LoginEndpoint>()
            .MapEndpoint<RegisterUserEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder routerBuilder)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(routerBuilder);

        return routerBuilder;
    }
 
}