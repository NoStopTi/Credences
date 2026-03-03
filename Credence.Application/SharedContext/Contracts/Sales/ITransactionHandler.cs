using Credence.Domain.SalesContext;
using Credence.Application.SharedContext.Responses;
using Credence.Infrastructure.SharedContext.UseCases.Responses;
using Credence.Application.SalesContext.UseCases.Transactions.Requests;

namespace Credence.Application.SharedContext.Contracts.Sales;

public interface ITransactionHandler
{
    Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request);
    Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request);
    Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request);
    Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request);
    Task<PagedResponse<List<Transaction>>> GetByPeriodAsync(GetTransactionsByPeriodRequest request);
}
