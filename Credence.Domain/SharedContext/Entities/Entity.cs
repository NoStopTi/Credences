
using System.ComponentModel.DataAnnotations.Schema;
using Credence.Domain.SharedContext.ValueObjects;
using Flunt.Notifications;

namespace Credence.Domain.SharedContext.Entities;

public abstract class Entity : Notifiable<Notification>, IEquatable<Guid>
{
    [NotMapped]
    private string email { get; set; } = string.Empty;
    protected Entity() => Id = Guid.NewGuid();
    public virtual Guid Id { get; set; }
    public virtual DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public virtual DateTime? IsDeletedAt { get; set; } = DateTime.MinValue;
    public virtual DateTime? UpdatedAt { get; set; } = DateTime.MinValue;
    public virtual string? Email { get => new Email(email); set => new Email(value ?? null!); }
    public virtual Guid? UserId { get; set; }
    public virtual Guid CompanyId { get; set; }
    public bool Equals(Guid id) => Id == id;
    public override int GetHashCode() => Id.GetHashCode();
    private protected void SetId(Guid? id) => Id = id ?? Guid.NewGuid();
    public void SetCreatedAt() => CreatedAt = DateTime.UtcNow;
    private protected void SetFakeDelete() => IsDeletedAt = DateTime.UtcNow;
    // public void BuildEmail(string email) => Email = new Email(email);
}

