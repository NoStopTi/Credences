using Credence.Application.SharedContext.Contracts.AccountStatus;
using Credence.Domain.UserContext.Entities;

using Microsoft.AspNetCore.Identity;

namespace Credence.Application.UserContext.UseCases.Services.AccountStatus;

public class GetStatusService(UserManager<User> userManager)
                                    : IGetStatusServices
{
    public async Task<UserAccountStatus> GetUserAccountStatus(User user)
    {
        // //AssertionConcern.AssertArgumentNotNull(user, Errors.ParamNotNullOrEmpty);

        var isEmailConfirmed = await userManager.IsEmailConfirmedAsync(user);
        var lockoutEnabled = user.LockoutEnabled;
        var isLockedOut = await userManager.IsLockedOutAsync(user);
        var lockoutEnd = user.LockoutEnd;
        var totalAccessFailedCount = user.AccessFailedCount;


        var status = new UserAccountStatus(isEmailConfirmed,
                                           lockoutEnabled,
                                           isLockedOut,
                                           lockoutEnd,
                                           totalAccessFailedCount);


        return status;

    }


}