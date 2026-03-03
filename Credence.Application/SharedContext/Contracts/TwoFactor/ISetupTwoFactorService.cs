
using Credence.Application.UserContext.TwoFactor.UseCases.Responses;
using Credence.Application.SharedContext.Responses;
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.TwoFactor;

public interface ISetupTwoFactorService
{
    Task<Response<WithAppSetupResponse>> AppVerifySetupTwoFactor(User user);
}