
using Credence.Domain.AuthContext.Entities;
using Credence.Domain.UserContext.Entities;
using Credence.Infrastructure.Data;
using Credence.Infrastructure.SharedContext.Repository;
using Credence.Infrastructure.UserContext;


namespace Credence.Application.UserContext.UseCases.Services;

public class UserRoleRepository : Repository<UserRole>, IUserRoleRepository
{
    private readonly CredenceDbContext _CONTEXT;
    public UserRoleRepository(CredenceDbContext CONTEXT) : base(CONTEXT)
    {
        _CONTEXT = CONTEXT;
    }

    public async Task<bool> AddUserRoleAsync(User user, Guid roleId, Guid companyId)
    {
        var userRole = new UserRole(user, roleId, companyId);

        var result =  await _CONTEXT.UserRoles.AddAsync(userRole);

        //mudar isso

        return await _CONTEXT.SaveChangesAsync() > 0;

        // return result.Entity != null ? true : false;
    }

    public async Task<bool> AddAsync(UserRole userRole)
    {
        var result = await _CONTEXT.UserRoles.AddAsync(userRole);

        return result.Entity != null ? true : false;
    }
    
}