namespace Credence.Default.DomainContext.Entities.Constants.SharedContext;

public record ImageConst
{
    #region Mapping
    public const string Required = "This field is required.";
    public const string HasColumnName = "Image";

    public const int ImageMax = 300;
    public const string ImageMaxMsg = "Image path cannot exceed 300 characters.";
    #endregion

    #region ERRORS
    public const string InvalidExtension = "Invalid image extension.";
    public const string InvalidPath = "Invalid image path.";
    #endregion

    #region DATA
    public static string InvalidPathValue = "..";
    public static string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };
    #endregion


}