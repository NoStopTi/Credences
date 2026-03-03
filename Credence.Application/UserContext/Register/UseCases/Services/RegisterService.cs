using Credence.Application.SharedContext.Contracts.Register;
using Credence.Application.UserContext.Register.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Credence.Default.DomainContext.Entities.Constants.CompanyContext;
using Credence.Default.Messages;
using Credence.Domain.UserContext.Entities;
using Credence.Infrastructure.UserContext.UseCases.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Credence.Application.SharedContext.Contracts.Authorization.Role;

namespace Credence.Application.UserContext.Register.UseCases.Services;

public class RegisterService(IUserRepository userRepository, IRolesServices rolesServices) : IRegisterService
{
    public async Task<Response<IdentityResult>> RegisterUserAsync(RegisterUserRequest request)
    {
        var userManager = userRepository.UserManager();

        var user = new User(request.Email);

        await AddAdminUserRoles(user, Guid.Parse(RoleConst.AdminIdGuid), Guid.Parse(CompanyConst.CompanyId));

        var userCreated = await userManager.CreateAsync(user, request.Password);

        return new Response<IdentityResult>(userCreated, StatusCodes.Status201Created, Successes.Created);
    }
    private async Task AddAdminUserRoles(User user, Guid roleId, Guid companyId) =>
                                        await rolesServices.AddUserRoleAsync(user, roleId, companyId);
}