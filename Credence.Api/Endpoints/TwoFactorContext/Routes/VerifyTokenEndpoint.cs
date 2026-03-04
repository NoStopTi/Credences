using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Application.UserContext.TwoFactor.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;
using Microsoft.AspNetCore.Mvc;
using Credence.Application.UserContext.Login.UseCases.Responses;

namespace Credence.Api.Endpoints.TwoFactorContext.Routes;

public class VerifyTokenEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        var endpoint = app.MapPost(TwoFactorConst.VerifyTokenRoute, HandlerAsync)
                                                                    .WithName(TwoFactorConst.VerifyTokenRoute)
                                                                    .WithDescription(TwoFactorConst.VerifyTokenRouteDesc)
                                                                    .WithOrder(TwoFactorConst.VerifyTokenRouteOrder)
                                                                    .Produces<Response<LoginResponse>>();
    }

    private static async Task<IResult> HandlerAsync(
                                            [FromBody] VerifyTwoFactorRequest request,
                                            [FromServices] ITwoFactorHandler handler
                                          )
    {

        var result = await handler.VerifyCodeAsync(request);

        return TypedResults.Ok(result);
    }
}
