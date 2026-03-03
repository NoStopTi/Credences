
namespace Credence.Default.DomainContext.Entities.Constants.AuthContext;

public record RoleConst
{
    #region MAPPING
    public const string ToTable = "AU_Roles";//AU_ == Authentication
    public const int NameMax = 256;
    public const int DisplayRoleNameMax = 256;
    public const string NameRequired = "Name is required.";
    public const string NameMaxMsg = "Name cannot exceed 256 characters.";
    public const int NormalizedNameMax = 256;
    public const string NormalizedNameRequired = "NormalizedName is required.";
    public const string NormalizedNameMaxMsg = "NormalizedName cannot exceed 256 characters.";
    public const string RoleRemoved = "Role removed";
    public const string RoleAdded = "Role Added";
    public const string IdHasColumnName = "Id";
    public const string IdHasColumnType = "BINARY(16)";

    #region DATA DEFAULT
    public const string AdminIdGuid = "3f2504e0-4f89-41d3-9a0c-0305e82c3301";
    public static Guid IdGuid = new Guid("3f2504e0-4f89-41d3-9a0c-0305e82c3301");
    public const string AdminConcurrencyStampGuid = "9a7b6c5d-1234-4abc-8def-1a2b3c4d5e6f";
    public const string AdminRoleName = "admin";
    public const string AdminNormalizedName = "ADMIN";
    public const string AdminDisplayRoleName = "Administrador";
    //TwoFactorPending
    public const string TwoFactorPendingIdGuid = "8c1f6b2e-3d4a-4f7c-9b12-6e5a9d3c4f81";
    public const string TwoFactorConcurrencyStampGuid = "b7a3c9f4-2e61-4d8b-a5c2-9f3e7a1d6b80";
    public const string TwoFactorRolePendingName = "two_factor_pending";
    public const string TwoFactorNormalizedName = "TWO_FACTOR_PENDING";
    public const string TwoFactorDisplayRoleName = "Two-Factor Pending";
    #endregion
    #endregion

}