using Credence.Api.Endpoints.CategoryContext.Routes;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

namespace Credence.Api.Endpoints.CategoryContext;

public static class CategoryEndpointExtension
{
    public static void EnpointsCatecoriesMap(this WebApplication app)
    {


        app.MapGroup(CategoryConst.GroupRoute)
            .WithTags(CategoryConst.GroupRouteTag)
            .MapEndpoint<CreateCategoryEndpoint>()
            .MapEndpoint<UpdateCategoryEndpoint>()
            .MapEndpoint<DeleteCategoryEndpoint>()
            .MapEndpoint<GetCategoryByIdEndpoint>()
            .MapEndpoint<GetAllCategoriesEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder routerBuilder)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(routerBuilder);

        return routerBuilder;
    }

}