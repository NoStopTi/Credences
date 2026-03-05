using Credence.Application.UserContext.Login.UseCases.Enums;

using Credence.Default.CommonContext;
using Credence.Domain.UserContext.Entities;
using Flunt.Notifications;
using Credence.Infrastructure.UserContext.UseCases.Abstractions;
using Credence.Application.SharedContext.Contracts.Validations;
using Credence.Default.Constants.UserContext;

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

    public async Task<IReadOnlyCollection<Notification>> Validate(User user)
    {
        var result = CheckUserLockoutType(await IsLockedOutAsync(user));

        if (result.LockoutType != ELockoutType.None)
            AddNotification(UserConst.Path_01, $"{UserConst.AccountHasBeenLocked} = {result.LockoutType}");

        return Notifications;
    }
   
}