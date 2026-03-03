
using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.UserContext.Entities;
using Flunt.Notifications;
using Microsoft.AspNetCore.Identity;
using Credence.Infrastructure.UserContext.UseCases.Abstractions;
using Credence.Default.Constants.UserContext;
using Credence.Default.Constants.EmailContext;
using Credence.Infrastructure.UserContext.UseCases.Responses;
using Credence.Infrastructure.UserContext.UseCases.Validations;

namespace Credence.Application.UserContext.UseCases.Get;

public class UserRepository(UserManager<User> userManager,
                            IValidation validation
                            ): Notifiable<Notification>, IUserRepository
{
    public async Task<Response?> EnsureNameOrEmailIsUniqueAsync(string nameOrEmail) =>
                                                                  await GetByUserName(nameOrEmail)
                                                                  ??
                                                                  await GetByEmail(nameOrEmail) ?? null!;
    public async Task<Response?> GetByUserName(string name)
    {
        validation.Required(name, ValidationsConst.GetByUserNameException, ValidationsConst.RequiredUserName)
                  .EmailAddress(name, ValidationsConst.GetByUserNameException, EmailConst.InvalidEmail);

        User user = null!;

        if (IsValid)
            user = await userManager.FindByNameAsync(name) ?? null!;


        return new Response(user, IsValid ? 200 : 400, IsValid ? string.Empty : $"{ValidationsConst.RequiredUserName} - {ValidationsConst.GetByUserNameException}");
    }
    public async Task<Response?> GetByEmail(Email email)
    {
        validation.EmailAddress(email, ValidationsConst.GetByUserNameException, EmailConst.InvalidEmail);
        User user = null!;

        if (IsValid)
            user = await userManager.FindByNameAsync(email) ?? null!;

        return new Response(user, IsValid ? 200 : 400, IsValid ? "" :$"{EmailConst.Required} {ValidationsConst.GetByEmailException}");

    }
    public async Task<Response?> GetById(Guid id)
    {
        validation.Required(id, ValidationsConst.GetByIdException, ValidationsConst.GetById_Required);

        var user = await userManager.FindByIdAsync(id.ToString());

        return new Response(user,  IsValid ? 200 : 400, IsValid ? "" :$"{ValidationsConst.GetByEmailException} - {ValidationsConst.GetById_Required}");
    }
    public UserManager<User> UserManager()
    {
        validation.Required(userManager, ValidationsConst.UserManager_001, ValidationsConst.RequiredUserName);
       
        return userManager;
    }
}