using Credence.Application.UserContext.UseCases.Validations;
using Credence.Domain.UserContext.Entities;
using Flunt.Notifications;

namespace Credence.Application.SharedContext.Contracts.Validations;

public interface IUserCanAuthenticateValidation
{
    Task<bool> IsLockedOutAsync(User user);
    CanAuthValidationResponse CheckUserLockoutType(bool isLockedOut);
    Task Validate(User user);
    Task<IReadOnlyCollection<Notification>> ValidateWithNotifications(User user);
}
