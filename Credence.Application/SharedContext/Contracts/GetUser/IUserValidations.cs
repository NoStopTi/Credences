// using Flunt.Notifications;

using Credence.Domain.UserContext.Entities;
using Flunt.Notifications;

namespace Credence.Application.SharedContext.Contracts.GetUser;

public interface IUserValidations
{
    // bool FullValidation(User user, string source);
    void IsValidForLogin(User user, string source);
    IReadOnlyCollection<Notification>? Notifications {get;}

    // void AddNotifications(Notification notification);
    // void AddNotifications(IReadOnlyCollection<Notification> notifications);
    // bool IsValid();
}