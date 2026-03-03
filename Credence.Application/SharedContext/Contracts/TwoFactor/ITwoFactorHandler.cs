using Credence.Application.UserContext.TwoFactor.UseCases.Requests;
using Credence.Application.UserContext.TwoFactor.UseCases.Responses;
using Credence.Application.UserContext.Login.UseCases.Responses;
using Credence.Application.SharedContext.Responses;

namespace Credence.Application.SharedContext.Contracts.TwoFactor;

public interface ITwoFactorHandler
{
    Task<Response<OnOffCodeViaEmailResponse>> OnOffCodeViaEmail(OnOffCodeViaEmailRequest request);
    Task<Response<WithAppSetupResponse>> SetupTwoFactor();
    Task<Response<LoginResponse>> VerifyCodeAsync(VerifyTwoFactorRequest request);
    Task<Response<EnableDisableResponse>> EnableDisableAsync(VerifyCodeEnableDisableRequest request);
}