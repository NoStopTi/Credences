
using Credence.Application.SharedContext.Contracts.Validations;
using Credence.Application.UserContext.Login.UseCases.Enums;

using Credence.Default.CommonContext;
using Flunt.Validations;
using Credence.Domain.UserContext.Entities;
using Flunt.Notifications;
using Credence.Default.Constants.UserContext;
using Credence.Infrastructure.UserContext.UseCases.Abstractions;
namespace Credence.Application.UserContext.UseCases.Validations;

public class UserCanAuthenticateValidation(IUserRepository userManager) : Notifiable<Notification>, IUserCanAuthenticateValidation
{
    public bool IsLockedOut { get; private set; }
    public DateTimeOffset? LockoutEnd { get; private set; }
    public bool LockoutEnabled { get; private set; }
    public int AccessFailedCount { get; private set; }

    public async Task<bool> IsLockedOutAsync(User user)
    {
        var manager = userManager.UserManager();

        return await manager!.IsLockedOutAsync(user ?? null!);
    }

    public CanAuthValidationResponse CheckUserLockoutType(bool isLockedOut)
    {

        if (isLockedOut)
        {
            if (IsTemporarilyLocked())
                return new CanAuthValidationResponse(ELockoutType.Temporarily,
                                                                 LockoutEnd.RemainingLockoutTime());
            else
                return new CanAuthValidationResponse(ELockoutType.Indefinite,
                                                                 TimeSpan.MaxValue);
        }

        return CanAuthValidationResponse.UserAccountNotLocked();
    }

    public bool IsTemporarilyLocked()
                                 => LockoutEnd < DateTimeOffset.MaxValue ? true : false;

    public async Task Validate(User user)
    {
        var result = CheckUserLockoutType(await IsLockedOutAsync(user));

        if (result.LockoutType != ELockoutType.None)
            AddNotification("UserCanAuthenticateValidation.Validate", $"{UserConst.AccountHasBeenLocked} = {result.LockoutType}");

    }
    public async Task<IReadOnlyCollection<Notification>> ValidateWithNotifications(User user)
    {

        var result = CheckUserLockoutType(await IsLockedOutAsync(user));

        AddNotifications(new Contract<bool>().IsTrue(result.LockoutType == ELockoutType.None,
                                                             $@"{UserConst.AccountHasBeenLocked}: 
                                                     {UserConst.AccountLockoutType} 
                                                     {result.LockoutType}
                                                     {UserConst.LoginErroPlaceNotification}"));
        return Notifications;
    }
}