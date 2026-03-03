using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Application.UserContext.TwoFactor.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;
using Microsoft.AspNetCore.Mvc;

namespace Credence.Api.Endpoints.TwoFactorContext.Routes;

public class OnOffCodeViaEmailEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        var endpoint = app.MapPost(TwoFactorConst.OnOffCodeEmailRoute, HandlerAsync)
        .WithName(TwoFactorConst.OnOffCodeEmailRoute)
        .WithDescription(TwoFactorConst.OnOffCodeEmailDesc)
        .WithOrder(TwoFactorConst.OnOffCodeEmailOrder)
        .Produces<Response<bool>>();
    }

    private static async Task<IResult> HandlerAsync(
                                            [FromBody] OnOffCodeViaEmailRequest request,
                                            [FromServices] ITwoFactorHandler handler
                                          )
    {

        var result = await handler.OnOffCodeViaEmail(request);

        return TypedResults.Ok(result);
    }
}
