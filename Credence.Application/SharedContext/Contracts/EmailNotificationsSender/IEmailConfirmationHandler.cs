
using Credence.Application.UserContext.EmailConfirmation.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.UserContext.Contracts;

public interface IEmailConfirmationHandler
{
   Task<Response<IdentityResult>> ConfirmEmailAddressAsync(EmailConfirmationRequest request);
}
