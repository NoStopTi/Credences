
using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.UseCases.Transactions.Requests;

public class GetTransactionByIdRequest : Request
{
    public Guid Id { get; set; }
}