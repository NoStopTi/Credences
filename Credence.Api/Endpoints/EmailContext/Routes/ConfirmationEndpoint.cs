using Credence.Application.UserContext.Contracts;
using Credence.Application.UserContext.EmailConfirmation.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Default.Constants.EmailContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Credence.Api.Endpoints.EmailContext.Routes;


public class ConfirmationEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost(EmailConst.ConfirmEmail, HandlerAsync)
              .WithName(EmailConst.ConfirmEmail)
              .WithDescription(EmailConst.ConfirmEmailDesc)
              .WithOrder(EmailConst.ConfirmEmailOrder)
              .Produces<Response<IdentityResult>>();

    private static async Task<IResult> HandlerAsync([FromBody] EmailConfirmationRequest request,
                                        IEmailConfirmationHandler handler)
    {
        var result = await handler.ConfirmEmailAddressAsync(request);

        return result.IsSuccess
        ? TypedResults.Created($"/{request.Email}", result)
        : TypedResults.BadRequest(result.Data);
    }
}
