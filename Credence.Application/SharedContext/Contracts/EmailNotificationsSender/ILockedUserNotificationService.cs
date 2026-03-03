namespace Credence.Application.SharedContext.Contracts.EmailNotifications;

public interface ILockedUserNotificationService
{
       Task UserLockedNotificationAsync(string displayName, string to);
       Task UserTemporarilyLockedNotificationAsync(string displayName, string to, string timeRemaining);
}