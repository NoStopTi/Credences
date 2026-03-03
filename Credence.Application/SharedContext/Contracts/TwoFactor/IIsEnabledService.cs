
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.TwoFactor;

public interface IIsEnabledService
{
    Task<bool> IsEnabled2FA(User user);
}
