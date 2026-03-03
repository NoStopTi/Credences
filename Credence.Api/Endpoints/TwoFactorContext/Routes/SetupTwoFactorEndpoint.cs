using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Application.UserContext.TwoFactor.UseCases.Responses;
using Credence.Application.SharedContext.Responses;
using Credence.Default.DomainContext.Entities.Constants.TwoFactorContext;
using Microsoft.AspNetCore.Mvc;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Microsoft.AspNetCore.Authorization;

namespace Credence.Api.Endpoints.TwoFactorContext.Routes;

public class SetupTwoFactorEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        var endpoint = app.MapPost(TwoFactorConst.SetupTwoFactorWithApp, HandlerAsync)
                                .WithName(TwoFactorConst.SetupTwoFactorWithApp)
                                .WithDescription(TwoFactorConst.WithAppSetupDesc)
                                .WithOrder(TwoFactorConst.WithAppSetupOrder)
                                .Produces<Response<WithAppSetupResponse>>()
                                .RequireAuthorization(new AuthorizeAttribute { Roles = RoleConst.AdminRoleName });
    }

    private static async Task<IResult> HandlerAsync([FromServices] ITwoFactorHandler handler)
    {
        var result = await handler.SetupTwoFactor();

        return TypedResults.Ok(result);
    }
}
