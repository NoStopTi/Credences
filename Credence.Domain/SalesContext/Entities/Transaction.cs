using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Credence.Default.DomainContext.Entities.Constants.SalesContext;
using Credence.Domain.SalesContext.Entities;
using Credence.Domain.SalesContext.Enums;
using Credence.Domain.SharedContext.Entities;

namespace Credence.Domain.SalesContext;

public class Transaction : Entity
{
    [NotMapped]
    public override DateTime? IsDeletedAt { get; set; } = null!;
    [NotMapped]
    public override DateTime? UpdatedAt { get; set; } = null!;

    [MaxLength(TransactionConst.TitleMax, ErrorMessage = TransactionConst.TitleMaxMsg)]
    public string Title { get; set; } = string.Empty;
    public DateTime? PaidOrReceivedAt { get; set; }
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
    public decimal Amount { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; } = null!;
    // public string UserId { get; set; } = string.Empty;
}