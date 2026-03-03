
using Credence.Api.Endpoints.TransactionsContext.Routes;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

namespace Credence.Api.Endpoints.TransactionsContext;

public static class TransactionsEndpointExtension
{
    public static void EnpointsTransactionsMap(this WebApplication app)
    {

            app.MapGroup(TransactionConst.GroupRoute)
                     .WithTags(TransactionConst.GroupRouteTag)
                     .MapEndpoint<CreateTransactionEndpoint>()
                     .MapEndpoint<UpdateTransactionEndpoint>()
                     .MapEndpoint<DeleteTransactionEndpoint>()
                     .MapEndpoint<GetTransactionByIdEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder routerBuilder)
    where TEndpoint : IEndpoint
    {
        TEndpoint.Map(routerBuilder);

        return routerBuilder;
    }

}