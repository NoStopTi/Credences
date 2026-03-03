
using Microsoft.AspNetCore.Identity;
using Credence.Domain.UserContext.Entities;
using Credence.Domain.AuthContext.Entities;
using Credence.Application.AuthContext.UseCases.Requests;
using Credence.Application.SharedContext.Contracts.Authorization.Role;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Credence.Infrastructure.UserContext.UseCases.Abstractions;
using Credence.Infrastructure.UserContext;

namespace Credence.Application.AuthContext.Roles.UseCases;

public class RolesServices : IRolesServices
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRoleRepository _userRoleDefaultRepository;
    private RoleManager<Role> _rolesManager { get; }

    public RolesServices(
    IUserRepository userRepository,
    RoleManager<Role> rolesManager,
    IUserRoleRepository userRoleDefaultRepository
    )
    {
        _userRepository = userRepository;
        _userRoleDefaultRepository = userRoleDefaultRepository;
        _rolesManager = rolesManager;

    }

    public static List<string> Roles => [];
    private async Task CanRemoveRole(bool delete, User user, string role)
    {
        if (delete)
        {
            var userManager = _userRepository.UserManager();

            await userManager.RemoveFromRoleAsync(user, role);

            Roles.Add($"{RoleConst.RoleRemoved} - {role}");
        }
    }
    public async Task<bool> IsInRoleAsync(User user, string role)
    {
        var userManager = _userRepository.UserManager();
        return await userManager.IsInRoleAsync(user, role);
    }

    private async Task AddToRoleAsync(User user, string role)
    {
        var userManager = _userRepository.UserManager();
        await userManager.AddToRoleAsync(user, role);
    }

    public async Task<string[]> UpdateUserRoles(UpdateUserRoleRequest[] roles)
    {
        var results = new List<string>();

        foreach (var role in roles)
        {
            var response = await _userRepository.GetByUserName(role.UserName);

            await CanRemoveRole(role.Delete, response!.User ?? null!, role.Role);

            if (!await IsInRoleAsync(response.User ?? null!, role.Role))
                await AddToRoleAsync(response.User ?? null!, role.Role);

            results.Add($"{RoleConst.RoleAdded} - {role}");
        }

        return results.ToArray();
    }

    public async Task<IList<string>> GetRolesAsync(User user)
    {
        var usersManager = _userRepository.UserManager();

        return await usersManager.GetRolesAsync(user);
    }

    public async Task<IdentityResult> CreateRoleAsync(RoleRequest role) => await _rolesManager.CreateAsync(new Role { Name = role.Name, DisplayRoleName = role.DisplayRoleName });

    public async Task<bool> AddUserRoleAsync(User user, Guid roleId, Guid companyId) => await _userRoleDefaultRepository.AddUserRoleAsync(user, roleId, companyId);

    public async Task<bool> AddUserRoleDefaultUSERAsync(UserRole userRole) => await _userRoleDefaultRepository.AddAsync(userRole);
}