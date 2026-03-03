using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Application.UserContext.TwoFactor.UseCases.Responses;
using Credence.Application.SharedContext.Responses;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;
using Microsoft.AspNetCore.Mvc;
using Credence.Application.UserContext.TwoFactor.UseCases.Requests;
using Microsoft.AspNetCore.Authorization;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;

namespace Credence.Api.Endpoints.TwoFactorContext.Routes;

public class EnableDisableEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        var endpoint = app.MapPost(TwoFactorConst.EnableDisableRoute, HandlerAsync)
                                                                    .WithName(TwoFactorConst.EnableDisableRoute)
                                                                    .WithDescription(TwoFactorConst.EnableDisableRouteDesc)
                                                                    .WithOrder(TwoFactorConst.EnableDisableRouteOrder)
                                                                    .Produces<Response<EnableDisableResponse>>()
                                                                    .RequireAuthorization(new AuthorizeAttribute {Roles = RoleConst.AdminRoleName});
    }

    private static async Task<IResult> HandlerAsync(
                                            [FromBody] VerifyCodeEnableDisableRequest request,
                                            [FromServices] ITwoFactorHandler handler
                                          )
    {

        var result = await handler.EnableDisableAsync(request);

        return TypedResults.Ok(result);
    }
}
