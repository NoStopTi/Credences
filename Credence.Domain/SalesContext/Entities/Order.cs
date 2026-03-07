using Credence.Domain.SalesContext.Enums;

namespace Credence.Domain.SalesContext.Entities;

public class Order
{
    public long Id { get; private set; }
    public string Number { get; private set; } = string.Empty;
    public string? ExternalReference { get; private set; } = null;
    public EPaymentGateway Gateway { get; private set; } = EPaymentGateway.Stripe;
    public DateTime CreateAt { get; private set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
    public EOrderStatus Status { get; private set; } = EOrderStatus.WaitingPayment;
    public long ProductId { get; private set; }
    public Product Product { get; private set; } = null!;
    public long? VoucherId { get; private set; }
    public Voucher Voucher { get; private set; } = null!;
    public string UserId { get; private set; } = string.Empty;
    public decimal Total => Product.Price - (Voucher?.Amount ?? 0);

}
