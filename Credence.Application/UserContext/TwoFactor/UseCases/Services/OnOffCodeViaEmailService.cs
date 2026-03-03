using Credence.Application.SharedContext.Contracts.TwoFactor;
using Credence.Domain.UserContext.Entities;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.UserContext.TwoFactor.UseCases.Services;


public class OnOffCodeService(UserManager<User> userManager) : IOnOffCodeService
{
    public async Task<bool> OnOffCodeViaEmail(User user, bool onOff)
    {

        user.Send2FACodeByEmail(onOff);

        var result = await userManager.UpdateAsync(user);

       return result.Succeeded ? true :  false;

    }
}