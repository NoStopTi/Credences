using Credence.Domain.AuthContext.Entities;
using Credence.Domain.SharedContext.ValueObjects;
using Credence.Domain.UserContext.ValueObjects;
using Microsoft.AspNetCore.Identity;

namespace Credence.Domain.UserContext.Entities;

public class User : IdentityUser<Guid>
{
    private readonly IList<UserCompany>? _userCompanies = [];
    private readonly IList<UserRole>? _userRoles = [];
    User() { }
    public User(string email)
    {
        var emailSplited = email.Split('@')[0];

        UserName = email;
        Email = email;

        Name = new Name().SetFirstName(emailSplited).SetDisplayName(emailSplited);
        
    }

    public Name? Name { get; set; } = null!;
    public LoginOptions? LoginOptions { get; private set; }
    public PasswordExpire? PasswordExpire { get; private set; }
    public TwoFactor? SendCodeByEmailDisabledAt { get; private set; }
    public Image? Image { get; private set; }
    public Age? Age { get; private set; }
    public Gender? Gender { get; private set; }
    public IReadOnlyCollection<UserCompany>? UserCompanies => _userCompanies!.ToList();
    public IReadOnlyCollection<UserRole>? UserRoles => _userRoles!.ToList();

    // public User CreateUser()
    // {
    //     return new User()
    //     {
    //         Name
    //         LoginOptions
    //         PasswordExpire
    //         SendCodeByEmailDisabledAt
    //         Image
    //         Age
    //         Gender
    //     }
    // }

    public void SetLastLogin()
    {
        LoginOptions = DateTime.UtcNow;
    }
    public void AddUserCompany(UserCompany userCompany)
    {
        _userCompanies!.Add(userCompany);
    }
    public void AddUserRoles(UserRole userRole)
    {
        _userRoles!.Add(userRole);
    }

    public void ResetLockout()
    {
        PasswordExpire?.SetPasswordChangedAt(DateTime.MinValue);
        LockoutEnd = DateTimeOffset.MinValue;
        LockoutEnabled = true;
    }

    public void Send2FACodeByEmail(bool active) =>
                                                SendCodeByEmailDisabledAt
                                                = active
                                                ? DateTime.UtcNow : DateTime.MinValue;

    

}