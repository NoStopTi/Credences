using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.UserContext.Entities;
using Credence.Infrastructure.UserContext.UseCases.Responses;
using Microsoft.AspNetCore.Identity;

namespace Credence.Infrastructure.UserContext.UseCases.Abstractions;

public interface IUserRepository
{
     Task<Response?> GetByUserName(string name);
     Task<Response?> GetByEmail(Email email);
     Task<Response?> GetById(Guid id);
    UserManager<User> UserManager();
}