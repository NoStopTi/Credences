using Credence.Domain.CompanyContext.Entities;
using Credence.Domain.UserContext.Entities;

namespace Credence.Domain.AuthContext.Entities;

public class UserCompany
{
    public  DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public  DateTime? IsDeletedAt { get; set; } = DateTime.MinValue;
    public  DateTime? UpdatedAt { get; set; } = DateTime.MinValue;
    public  string? Email { get; set; }
    public  Guid? UserId { get; set; }
    public  User? User { get; set; }
    public  Guid? CompanyId { get; set; }
    public  Company? Company { get; set; }
}

