
using Credence.Application.UserContext.TwoFactor.UseCases.Responses;
using Credence.Application.SharedContext.Responses;
using Credence.Domain.UserContext.Entities;

namespace Credence.Application.SharedContext.Contracts.TwoFactor;

public interface IEnableDisableService
{
    Task<Response<EnableDisableResponse>> EnableDisableAsync(User user, bool enableDisable);
    // Task<Response<EnableDisableResponse>> EnableDisableAsync(User user, object enableDisable);
}