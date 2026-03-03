using System.Security.Claims;
using Credence.Domain.SalesContext;
using Microsoft.AspNetCore.Mvc;
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Application.SharedContext.Responses;
using Credence.Application.SalesContext.UseCases.Transactions.Requests;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

namespace Credence.Api.Endpoints.TransactionsContext.Routes;

public class GetTransactionByIdEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
    =>

    app.MapGet(TransactionConst.GetTransactionById, HandleAsync)
        .WithName(TransactionConst.GetTransactionById)
        .WithDescription(TransactionConst.GetTransactionByIdDesc)
        .WithOrder(TransactionConst.GetTransactionByIdOrder)
        .Produces<Response<Transaction?>>();

    private static async Task<IResult> HandleAsync
    (
        ClaimsPrincipal user,
        [FromServices] ITransactionHandler handler,
        Guid id
    )
    {
        var request = new GetTransactionByIdRequest
        {
        };

        var result = await handler.GetByIdAsync(request);

        return result.IsSuccess ?
               TypedResults.Ok(result) :
               TypedResults.BadRequest(result);

    }
}