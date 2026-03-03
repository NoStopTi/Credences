using Credence.Domain.UserContext.Entities;
using Credence.Domain.UserContext.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Credence.Application.SharedContext.Contracts.Passwords;

public interface IPasswordService
{
    Task<SignInResult> PasswordSignInAsync(User user,
                                           string password,
                                           bool isPersistent = true,
                                           bool lockoutOnFailure = false);
    Task<IdentityResult> ResetAccessFailedCountAsync(User user);

}