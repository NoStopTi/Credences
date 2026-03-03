
using Credence.Domain.SharedContext.AggregateRoots.Abstractions;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;

namespace Credence.Domain.AuthContext.Entities;


public class UserRole : IdentityUserRole<Guid>, IAggregateRoots
{
    public UserRole()
    {

    }
    public UserRole(User user, Role role)
    {
        User = user;
        Role = role;
    }
    public UserRole(User user, Role role, Guid companyId)
    {
        User = user;
        Role = role;
        CompanyId = companyId;
    }
    public UserRole(User user, Guid roleId, Guid companyId)
    {
        User = user;
        RoleId = roleId;
        CompanyId = companyId;
    }
    public User User { get; set; } = null!;
    public Guid? CompanyId { get; set; }
    public Role Role { get; set; } = null!;
}