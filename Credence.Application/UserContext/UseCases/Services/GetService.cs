using Credence.Application.SharedContext.Contracts.GetUser;
using Credence.Default.Constants.EmailContext;
using Credence.Default.Constants.UserContext;
using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.UserContext.Entities;
using Credence.Infrastructure.UserContext.UseCases.Abstractions;
using Credence.Infrastructure.UserContext.UseCases.Responses;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.UserContext.UseCases.Services;

public class GetService(IUserRepository users) : Notifiable<Notification>, IGetService
{

    public async Task<Response> EnsureNameOrEmailIsUniqueAsync(string nameOrEmail, string source) =>
                                                                  await GetByUserName(nameOrEmail, source)
                                                                  ??
                                                                  await GetByEmail(nameOrEmail, source) ?? null!;

    public async Task<Response?> GetByUserName(string name, string source)
    {
        Validate(name, source);

        var user = await users.GetByUserName(name);
        return user;
    }

    public async Task<Response?> GetByEmail(Email email, string source)
    {
        Validate(email, source);
        var user = await users.GetByEmail(email);
        return user;
    }

    public async Task<Response?> GetById(Guid id, string source)
    {
        Validate(id, source);
        var user = await users.GetById(id);
        return user;
    }

    public UserManager<User> UserManager() => users.UserManager();


    public void Validate(Guid id, string source)
    {
        AddNotifications(
                    new Contract<string>().Requires()
                    .IsNotNull(id, $"{source}, {UserConst.InvalidUser}"));
    }
    public void Validate(string nameOrEmail, string source)
    {
        AddNotifications(
            new Contract<string>().Requires()
            .IsEmail(nameOrEmail, $"{source}, {EmailConst.InvalidEmail}"));
    }

}