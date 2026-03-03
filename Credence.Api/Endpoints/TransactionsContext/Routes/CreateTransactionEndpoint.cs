using System.Security.Claims;
using Credence.Domain.SalesContext;
using Microsoft.AspNetCore.Mvc;
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Application.SharedContext.Responses;
using Credence.Application.SalesContext.UseCases.Transactions.Requests;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;

namespace Credence.Api.Endpoints.TransactionsContext.Routes;


public class CreateTransactionEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)

        => app.MapPost(TransactionConst.CreateTransaction, HandlerAsync)
              .WithName(TransactionConst.CreateTransaction)
              .WithDescription(TransactionConst.CreateTransactionDesc)
              .WithOrder(TransactionConst.CreateTransactionOrder)
              .Produces<Response<Transaction?>>();
    private static async Task<IResult> HandlerAsync
    (
    ClaimsPrincipal user,
    [FromServices] ITransactionHandler handler,
    CreateTransactionRequest request
    )
    {
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
        ? TypedResults.Created($"/{result.Data?.Id}", result)
        : TypedResults.BadRequest(result.Data);
    }
}