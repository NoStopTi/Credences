using Credence.Default.Messages;
using Credence.Domain.SalesContext;
using Credence.Domain.SalesContext.Enums;
using Credence.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Credence.Application.SharedContext.Contracts.Sales;
using Credence.Application.SharedContext.Responses;
using Credence.Infrastructure.SharedContext.UseCases.Responses;
using Credence.Application.SalesContext.UseCases.Transactions.Requests;

namespace Credence.Application.SalesContext.UseCases;



public class TransactionHandler(CredenceDbContext context) : ITransactionHandler
{
    public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {

        if (request is { Type: ETransactionType.Withdraw, Amount: >= 0 })
            request.Amount *= -1;

        try
        {

            var transaction = BuildEntity(request, null);

            await context.Transactions.AddAsync(transaction);

            await context.SaveChangesAsync();

            return new Response<Transaction?>(transaction, StatusCodes.Status201Created, Successes.Created);
        }
        catch
        {
            return new Response<Transaction?>(null, StatusCodes.Status500InternalServerError, Errors.InternalServerError);
        }
    }
    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        try
        {
            var transaction = await GetById(request.Id, request.UserId);

            if (transaction is null)
                return new Response<Transaction?>(null, StatusCodes.Status500InternalServerError, Errors.InternalServerError);

            context.Transactions.Remove(transaction);

            await context.SaveChangesAsync();

            return new Response<Transaction?>(transaction, StatusCodes.Status200OK, Successes.Deleted);
        }
        catch
        {
            return new Response<Transaction?>(null, StatusCodes.Status500InternalServerError, Errors.InternalServerError);
        }
    }
    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
    {
        try
        {
            var transaction = await GetById(request.Id, request.UserId, true);

            return transaction is null ? new Response<Transaction?>(
                                        null,
                                        StatusCodes.Status404NotFound,
                                        Errors.NotFound)
                                        :
                                        new Response<Transaction?>(
                                        transaction);
        }

        catch
        {
            return new Response<Transaction?>(null,
                                                    StatusCodes.Status500InternalServerError,
                                                    Errors.InternalServerError);
        }
    }

    public async Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
    {

        try
        {
            var query = context.Transactions
                .AsNoTracking()
                .Where(x =>
                        x.PaidOrReceivedAt >= request.StartDate &&
                        x.PaidOrReceivedAt <= request.EndDate &&
                        x.UserId == request.UserId
                        )
                        .OrderBy(x => x.Title);

            var transactions = await query
                .Skip(request.DefaultPagination())
                .Take(request.PageSize)
                .ToListAsync();

            return new PagedResponse<List<Transaction>>(transactions);
        }

        catch
        {
            return new PagedResponse<List<Transaction>>
            (null, StatusCodes.Status500InternalServerError, Errors.InternalServerError);
        }


    }
    public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        try
        {
            var transaction = await GetById(request.Id, request.UserId);

            if (transaction is null)
                return new Response<Transaction?>(null, StatusCodes.Status404NotFound, Errors.NotFound);

            var update = BuildEntity(request, transaction);

            context.Update(update);

            await context.SaveChangesAsync();

            return new Response<Transaction?>(update);

        }

        catch
        {
            return new Response<Transaction?>(null,
                                                    StatusCodes.Status500InternalServerError,
                                                    Errors.InternalServerError);
        }
    }

    private Transaction BuildEntity(Object request, Transaction? dbTransaction)
    {

        switch (request)
        {
            case CreateTransactionRequest create:
                {
                    var transaction = new Transaction
                    {
                        UserId = create.UserId,
                        CategoryId = create.CategoryId,
                        Amount = create.Amount,
                        PaidOrReceivedAt = create.PaidOrReceivedAt,
                        Title = create.Title,
                        Type = create.Type,

                    };

                    transaction.SetCreatedAt();

                    return transaction;
                }

            case UpdateTransactionRequest update:
                {
                    dbTransaction!.CategoryId = update.CategoryId;
                    dbTransaction.Amount = update.Amount;
                    dbTransaction.PaidOrReceivedAt = update.PaidOrReceivedAt;
                    dbTransaction.Title = update.Title;
                    dbTransaction.Type = update.Type;
                    dbTransaction.SetCreatedAt();
                    return dbTransaction;
                }

        }

        return null!;
    }
    private async Task<Transaction?> GetById(Guid id, Guid userId, bool traking = false)
    {
        return traking ?

         await context.Transactions
             .AsNoTracking()
                          .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId)
        :
        await context.Transactions
                            .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
    }

}