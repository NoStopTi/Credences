

namespace Credence.Api.Endpoints;

public static class TestsEndpoint
{
    public static void TestsEndpointMap(this WebApplication app)
    {
        var endpoints = app.MapGroup("");

         endpoints.MapGroup("/test")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "Its working..." });
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder routerBuilder)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(routerBuilder);

        return routerBuilder;
    }
 
}