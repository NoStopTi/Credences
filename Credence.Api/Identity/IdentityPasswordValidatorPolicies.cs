
using Credence.Default.Constants.PasswordContext;
using Credence.Domain.UserContext.ValueObjects;
using Microsoft.AspNetCore.Identity;


namespace Credence.Api.Identity;

public class IdentityPasswordValidatorPolicies<TUser> : IPasswordValidator<TUser> where TUser : class
{

    public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string? password)
    {
        var pwd = new Password(password ?? string.Empty);

        var userName = await manager.GetUserNameAsync(user);

        if (userName == pwd.Passwd)
            Error($"{PasswordConst.UsernameCannotSame}");

        if (pwd.Passwd.ToUpper().Contains(PasswordConst.PwdContainsPas))
            Error($"{PasswordConst.PwdCannotContains} {PasswordConst.PwdContainsPas}");

        if (pwd.Passwd.ToUpper().Contains(PasswordConst.PwdContainsSen))
            return Error($"{PasswordConst.PwdCannotContains} {PasswordConst.PwdContainsSen}");

        return IdentityResult.Success;
    }

    private IdentityResult Error(string msg) =>
                 IdentityResult.Failed(new IdentityError { Description = msg });

}