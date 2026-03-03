using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.TwoFactor;

public interface IVerifyCodeService
{
   Task<bool> IsValidCodeAsync(User user, string provider, string code);
}

