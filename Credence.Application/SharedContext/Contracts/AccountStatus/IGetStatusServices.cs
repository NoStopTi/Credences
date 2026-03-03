
using Credence.Application.UserContext.UseCases.Services.AccountStatus;
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.AccountStatus;

public interface IGetStatusServices
{
    Task<UserAccountStatus> GetUserAccountStatus(User user);
}