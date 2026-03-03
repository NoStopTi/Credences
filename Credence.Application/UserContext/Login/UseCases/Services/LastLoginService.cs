using Credence.Application.SharedContext.Contracts.Login;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Credence.Application.UserContext.Login.UseCases.Services;

public class LastLoginService([FromServices] UserManager<User> userManager) : ISetLastLogin
{
    public async Task SetLastLoginAsync(User user)
    {
        user.SetLastLogin();
        await userManager.UpdateAsync(user);
    }
}