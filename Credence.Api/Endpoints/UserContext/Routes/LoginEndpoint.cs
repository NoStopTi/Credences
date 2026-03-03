using Microsoft.AspNetCore.Mvc;
using Credence.Application.UserContext.UseCases.Login.Contracts;
using Credence.Application.SharedContext.Responses;
using Credence.Default.Constants.UserContext;
using Credence.Application.UserContext.Login.UseCases.Responses;
using Credence.Application.UserContext.Login.UseCases.Requests;

namespace Credence.Api.Endpoints.UserContext.Routes;

public class LoginEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    {
        var endpoints = app.MapPost(UserConst.Login, HandlerAsync)
        .WithName(UserConst.Login)
        .WithDescription(UserConst.LoginDesc)
        .WithOrder(3)
        .Produces<Response<LoginResponse>>();
    }
    private static async Task<IResult> HandlerAsync([FromBody] LoginUserRequest request,
                                                    [FromServices] ILoginHandler handler)
    {
        var result = await handler.Login(request);

        return result.IsSuccess 
                                ? TypedResults.Accepted(UserConst.Login, result)
                                : TypedResults.BadRequest(result.Data);
    }
}
