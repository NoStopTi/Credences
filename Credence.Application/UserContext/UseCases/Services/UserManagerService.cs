using Credence.Domain.UserContext.Entities;
using Credence.Application.SharedContext.Contracts.GetUser;
using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Credence.Infrastructure.UserContext.UseCases.Abstractions;

namespace Credence.Application.UserContext.UseCases.Services;

public class UserManagerService(IUserRepository users) : Notifiable<Notification>, IUserManagerService
{
    public UserManager<User> UserManager() => users.UserManager();
}