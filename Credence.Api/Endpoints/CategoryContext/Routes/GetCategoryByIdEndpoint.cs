using System.Security.Claims;
using Credence.Domain.SalesContext.Entities;
using Microsoft.AspNetCore.Mvc;
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Application.SharedContext.Responses;
using Credence.Application.SalesContext.UseCases.Categories.Requests;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

namespace Credence.Api.Endpoints.CategoryContext.Routes;

public class GetCategoryByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    =>

    app.MapGet(CategoryConst.GetCategoryById, HandleAsync)
        .WithName(CategoryConst.GetCategoryById)
        .WithDescription(CategoryConst.GetCategoryByIdDesc)
        .WithOrder(CategoryConst.GetCategoryByIdOrder)
        .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(ClaimsPrincipal user,
                                                   [FromServices] ICategoryHandler handler,
                                                   Guid id)
    {
        var request = new GetCategoryByIdRequest
        {
            Id = id,
        };

        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess ?
               TypedResults.Ok(result) :
               TypedResults.BadRequest(result);

    }
}