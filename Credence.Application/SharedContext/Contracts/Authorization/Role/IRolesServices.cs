using Credence.Application.AuthContext.UseCases.Requests;
using Credence.Domain.AuthContext.Entities;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;


namespace Credence.Application.SharedContext.Contracts.Authorization.Role;

public interface IRolesServices
{
    Task<bool> IsInRoleAsync(User user, string role);
    Task<string[]> UpdateUserRoles(UpdateUserRoleRequest[] roles);
    Task<IList<string>> GetRolesAsync(User user);
    Task<IdentityResult> CreateRoleAsync(RoleRequest role);
    Task<bool> AddUserRoleAsync(User user, Guid roleId, Guid companyId);
    Task<bool> AddUserRoleDefaultUSERAsync(UserRole userRole);
}