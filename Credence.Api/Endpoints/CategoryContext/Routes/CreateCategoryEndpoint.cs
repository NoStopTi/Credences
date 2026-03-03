using System.Security.Claims;
using Credence.Domain.SalesContext.Entities;
using Microsoft.AspNetCore.Mvc;
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Application.SharedContext.Responses;
using Credence.Application.SalesContext.UseCases.Categories.Requests;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

namespace Credence.Api.Endpoints.CategoryContext.Routes;


public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)

        => app.MapPost(CategoryConst.CreateCategory, HandlerAsync)
        .WithName(CategoryConst.CreateCategory)
        .WithDescription(CategoryConst.CreateCategoryDesc)
        .WithOrder(CategoryConst.CreateCategoryOrder)
        .Produces<Response<Category?>>();


    private static async Task<IResult> HandlerAsync
    (
    ClaimsPrincipal user,
    [FromServices] ICategoryHandler handler,
    CreateCategoryRequest request
    )
    {
        // request.UserId = user.Identity?.Name ?? string.Empty;
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
        ? TypedResults.Created(result.Data?.Id.ToString(), result)
        : TypedResults.BadRequest(result.Data);
    }
}