using Credence.Api.Endpoints.TwoFactorContext.Routes;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;

namespace Credence.Api.Endpoints.TwoFactorContext;

public static class TwoFactorEndpointExtension
{
    public static void TwoFactorEndpointMap(this WebApplication app)
    {
        app.MapGroup(TwoFactorConst.GroupRoute)
            .WithTags(TwoFactorConst.GroupRouteTag)
                    .MapEndpoint<SetupTwoFactorEndpoint>()
                    .MapEndpoint<EnableDisableEndpoint>()
                    .MapEndpoint<VerifyTokenEndpoint>()
                    .MapEndpoint<OnOffCodeViaEmailEndpoint>();
        ;
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder routerBuilder)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(routerBuilder);

        return routerBuilder;
    }

}