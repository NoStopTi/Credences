
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.TwoFactor;

public interface IOnOffCodeService
{
     Task<bool> OnOffCodeViaEmail(User user, bool onOff);
}