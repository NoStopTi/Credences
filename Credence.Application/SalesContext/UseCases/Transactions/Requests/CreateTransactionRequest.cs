
using System.ComponentModel.DataAnnotations;
using Credence.Application.SharedContext.Requests;
using Credence.Domain.SalesContext.Enums;

namespace Credence.Application.SalesContext.UseCases.Transactions.Requests;

public class CreateTransactionRequest : Request
{
    [Required(ErrorMessage = "Invalid title")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Invalid type")]
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;

    [Required(ErrorMessage = "Invalid amount")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Invalid category")]
    public Guid CategoryId { get; set; }

    [Required(ErrorMessage = "Invalid date")]
    public DateTime? PaidOrReceivedAt { get; set; }
}