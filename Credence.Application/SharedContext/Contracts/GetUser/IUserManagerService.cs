using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.SharedContext.Contracts.GetUser;
public interface IUserManagerService
{
    UserManager<User> UserManager();
}