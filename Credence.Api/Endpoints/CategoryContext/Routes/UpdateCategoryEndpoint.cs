using System.Security.Claims;

using Credence.Domain.SalesContext.Entities;
using Microsoft.AspNetCore.Mvc;
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Application.SharedContext.Responses;
using Credence.Application.SalesContext.UseCases.Categories.Requests;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

namespace Credence.Api.Endpoints.CategoryContext.Routes;

public class UpdateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)

        => app.MapPut(CategoryConst.UpdateCategory, HandlerAsync)
        .WithName(CategoryConst.UpdateCategory)
        .WithDescription(CategoryConst.UpdateCategoryDesc)
        .WithOrder(CategoryConst.UpdateCategoryOrder)
        .Produces<Response<Category?>>();
    private static async Task<IResult> HandlerAsync
        (ClaimsPrincipal user,
        [FromServices] ICategoryHandler handler,
        UpdateCategoryRequest request,
        Guid id)
    {
        request.Id = id;

        var result = await handler.UpdateAsync(request);

        return result.IsSuccess
        ? TypedResults.Created(result.Data?.Id.ToString(), result)
        : TypedResults.BadRequest(result.Data);
    }
}