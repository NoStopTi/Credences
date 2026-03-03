using Credence.Api.Endpoints.EmailContext.Routes;
using Credence.Default.Constants.EmailContext;

namespace Credence.Api.Endpoints.EmailContext;

public static class EmailEndpointExtension
{
    public static void EnpointsEmailMap(this WebApplication app)
    {                
        app.MapGroup(EmailConst.GroupRoute)
           .WithTags(EmailConst.WithTags)
           .WithOrder(EmailConst.ConfirmEmailOrder)
           .MapEndpoint<ConfirmationEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder routerBuilder)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(routerBuilder);

        return routerBuilder;
    }
 
}