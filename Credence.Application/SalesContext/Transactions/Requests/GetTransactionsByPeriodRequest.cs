
using Credence.Application.SharedContext.Requests;

namespace Credence.Application.SalesContext.Transactions.Requests;

public class GetTransactionsByPeriodRequest : PagedRequest
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}