
using Credence.Domain.AuthContext.Entities;
using Credence.Domain.UserContext.Entities;

namespace Credence.Infrastructure.UserContext;

public interface IUserRoleRepository
{
    Task<bool> AddAsync(UserRole userRole);
    Task<bool> AddUserRoleAsync(User user, Guid roleId, Guid companyId);

}