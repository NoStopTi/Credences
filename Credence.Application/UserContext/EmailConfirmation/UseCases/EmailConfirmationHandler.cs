using Credence.Application.UserContext.Contracts;
using Credence.Application.UserContext.EmailConfirmation.UseCases.Requests;
using Credence.Application.SharedContext.Responses;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Credence.Application.UserContext.EmailConfirmation.UseCases;

public class EmailConfirmationHandler([FromServices] UserManager<User> _userManager) : IEmailConfirmationHandler
{
    public async Task<Response<IdentityResult>> ConfirmEmailAddressAsync(EmailConfirmationRequest request)
    {
        var getUserByEmail = await _userManager.FindByEmailAsync(request.Email) ?? null!;
                                                                                         //decoding to confirm
        var result = await _userManager.ConfirmEmailAsync(getUserByEmail, request.Token.Decoded_UTF8_Base64());

        return new Response<IdentityResult>(result);
    }
}

