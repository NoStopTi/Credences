
using System.Security.Claims;
using Credence.Default.ApiContext.Configurations;
using Credence.Domain.SalesContext.Entities;
using Microsoft.AspNetCore.Mvc;
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Infrastructure.SharedContext.UseCases.Responses;
using Credence.Application.SalesContext.Categories.Requests;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

namespace Credence.Api.Endpoints.CategoryContext.Routes;

public class GetAllCategoriesEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)

        => app.MapDelete(CategoryConst.GetAllCategories, HandlerAsync)
        .WithName(CategoryConst.GetAllCategories)
        .WithDescription(CategoryConst.GetAllCategoriesDesc)
        .WithOrder(CategoryConst.GetAllCategoriesOrder)
        .Produces<PagedResponse<List<Category>>>();


    private static async Task<IResult> HandlerAsync
                (ClaimsPrincipal user,
                [FromServices] ICategoryHandler handler,
                [FromQuery] int pageNumber = ApiSettings.DefaultPageNumber,
                [FromQuery] int pageSize = ApiSettings.DefaultPageSize)
    {
        var request = new GetAllCategoriesRequest
        {
            // UserId = user.Identity?.Name ?? string.Empty,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };


        var result = await handler.GetAllAsync(request);

        return result.IsSuccess
        ? TypedResults.Ok(result)
        : TypedResults.BadRequest(result);

    }
}