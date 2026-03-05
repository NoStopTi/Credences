using Credence.Application.SharedContext.Contracts.Register;
using Credence.Application.UserContext.Register.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Default.Constants.UserContext;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Credence.Api.Endpoints.UserContext.Routes;


public class RegisterUserEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)

        => app.MapPost(UserConst.RegisterUser, HandlerAsync)
               .WithName(UserConst.RegisterUser)
               .WithDescription(UserConst.RegisterUserDesc)
               .WithOrder(1)
               .Produces<Response<User?>>();
    private static async Task<IResult> HandlerAsync
                                        ([FromBody] RegisterUserRequest request,
                                        [FromServices] IRegisterHandler handler)
    {

        var result = await handler.RegisterAsync(request);

        return result.IsSuccess
        ? TypedResults.Created(UserConst.RegisterResponse, result)
        : TypedResults.BadRequest(result.Data);
    }
}