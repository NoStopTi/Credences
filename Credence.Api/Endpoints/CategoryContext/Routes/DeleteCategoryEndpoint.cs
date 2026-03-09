using System.Security.Claims;
using Credence.Domain.SalesContext.Entities;
using Microsoft.AspNetCore.Mvc;
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Application.SharedContext.Responses;
using Credence.Application.SalesContext.Categories.Requests;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

namespace Credence.Api.Endpoints.CategoryContext.Routes;


public class DeleteCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)

        => app.MapDelete(CategoryConst.DeleteCategory, HandlerAsync)
        .WithName(CategoryConst.DeleteCategory)
        .WithDescription(CategoryConst.DeleteCategoryDesc)
        .WithOrder(CategoryConst.DeleteCategoryOrder)
        .Produces<Response<Category?>>();


    private static async Task<IResult> HandlerAsync
    (
    ClaimsPrincipal user,
    [FromServices] ICategoryHandler handler,
    Guid id
    )
    {
        var request = new DeleteCategoryRequest
        {
            // UserId = user.Identity?.Name ?? string.Empty,
            Id = id
        };

        var result = await handler.DeleteAsync(request);

        return result.IsSuccess
                  ? TypedResults.Ok(result)
                  : TypedResults.BadRequest(result);
    }
}