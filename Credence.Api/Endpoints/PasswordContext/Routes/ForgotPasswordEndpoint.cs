
using Credence.Application.SharedContext.Contracts.Passwords;
using Credence.Application.UserContext.Passwords.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Default.Constants.PasswordContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Credence.Api.Endpoints.PasswordContext.Routes;

public class ForgotPasswordEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)

        => app.MapPost(PasswordConst.ForgotPassword, HandlerAsync)
              .WithName(PasswordConst.ForgotPassword)
              .WithDescription(PasswordConst.ForgotPasswordDesc)
              .WithOrder(PasswordConst.ForgotPasswordOrder)
              .Produces<Response<IdentityResult>>();

    private static async Task<IResult> HandlerAsync([FromBody] ForgotRequest request,
                                                    IForgotHandler handler)
    {
        var result = await handler.ForgotPasswordAsync(request);

        return result.IsSuccess
        ? TypedResults.Created($"/{request.Email}", result)
        : TypedResults.BadRequest(result.Data);
    }
}
