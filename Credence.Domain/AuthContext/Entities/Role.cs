using System.ComponentModel.DataAnnotations;
using Credence.Default.DomainContext.Entities.Constants.AuthContext;
using Microsoft.AspNetCore.Identity;

namespace Credence.Domain.AuthContext.Entities;


public class Role : IdentityRole<Guid>
{
    public Role()
    {

    }
    public Role(Guid roleId)
    {
        Id = roleId;
    }
    public Role(string roleName, string displayRoleName)
    {
        Name = roleName;
        DisplayRoleName = displayRoleName;
    }

    public List<UserRole>? UserRoles { get; private set; }
    [Required(ErrorMessage = RoleConst.NameRequired), MaxLength(RoleConst.NameMax, ErrorMessage = RoleConst.NameMaxMsg)]
    public string DisplayRoleName { get; set; } = string.Empty;
    public override string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = RoleConst.NameRequired), MaxLength(RoleConst.NameMax, ErrorMessage = RoleConst.NameMaxMsg)]
    public override string? Name { get; set; } = string.Empty;
    [Required(ErrorMessage = RoleConst.NormalizedNameRequired), MaxLength(RoleConst.NormalizedNameMax, ErrorMessage = RoleConst.NormalizedNameMaxMsg)]
    public override string? NormalizedName { get; set; } = string.Empty;

}
