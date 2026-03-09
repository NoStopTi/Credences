using System.Security.Claims;
using Credence.Domain.SalesContext;
using Microsoft.AspNetCore.Mvc;
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Application.SharedContext.Responses;
using Credence.Application.SalesContext.Transactions.Requests;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

namespace Credence.Api.Endpoints.TransactionsContext.Routes;


public class DeleteTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)

        => app.MapDelete(TransactionConst.DeleteTransaction, HandlerAsync)
        .WithName(TransactionConst.DeleteTransaction)
        .WithDescription(TransactionConst.DeleteTransactionDesc)
        .WithOrder(TransactionConst.DeleteTransactionOrder)
        .Produces<Response<Transaction?>>();


    private static async Task<IResult> HandlerAsync
    (
    ClaimsPrincipal user,
    [FromServices] ITransactionHandler handler,
    Guid id
    )
    {
        var request = new DeleteTransactionRequest
        {
        };

        var result = await handler.DeleteAsync(request);

        return result.IsSuccess
                  ? TypedResults.Ok(result)
                  : TypedResults.BadRequest(result);
    }
}