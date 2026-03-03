using Credence.Application.SharedContext.Contracts.Passwords;
using Credence.Application.UserContext.Passwords.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Default.Constants.PasswordContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Credence.Api.Endpoints.PasswordContext.Routes;

public class ResetPasswordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        var endpoints = app.MapPost(PasswordConst.PasswordReset, HandlerAsync)
        .WithName(PasswordConst.PasswordReset)
        .WithDescription(PasswordConst.PasswordResetDesc)
        .WithOrder(PasswordConst.PasswordResetOrder)
        .Produces<Response<IdentityResult>>();
    }

    private static async Task<IResult> HandlerAsync(
                                            [FromBody] ResetRequest request,
                                            [FromServices] IResetHandler handler
                                            )
    {
       var result = await handler.ResetPasswordAsync(request);
       return result.IsSuccess ? TypedResults.Accepted(PasswordConst.PasswordReset, result) : TypedResults.BadRequest(result.Data);
    }
}
