
using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.Transactions.Requests;

public class DeleteTransactionRequest : Request
{
    public Guid Id { get; set; }
}