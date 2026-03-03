
namespace Credence.Default.DomainContext.Entities.Constants.ProfileContext;

public record SocialNetworkConst
{


    #region MAPPING
    public const string ToTable = "PF_SocialNetworks";//PF_ == ProFile
    public const string IdHasColumnName = "Id";
    public const string HasColumnName = "SocialNetworks";
    public const string IdHasColumnType = "BIGINT";
    public const string NameUrlHasColumnType = "VARCHAR";
    public const int NameMax = 30;
    public const string NameMaxMsg = "Name cannot exceed 30 characters.";

    //MAPPING Url
    public const int UrlMax = 300;
    public const string UrlMaxMsg = "Url cannot exceed 300 characters.";
    #endregion

}






