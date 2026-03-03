namespace Credence.Default.DomainContext.Entities.Constants.ProfileContext;

public record PhoneConst
{
    #region  WARNING
    public const string Required = "At least one phone number is required";

    #endregion

    #region  MAPPING LandLine

    public const int LandlineMax = 11;
    public const string LandlineMaxMsg = "number cannot exceed 11 digits.";

    #endregion

    #region  MAPPING Mobile

    public const int MobileMax = 11;
    public const string MobileMaxMsg = "Mobile number cannot exceed 11 digits.";

    #endregion

    #region  MAPPING Work

    public const int WorkMax = 11;
    public const string WorkMaxMsg = "Work phone number cannot exceed 11 digits.";

    #endregion

    #region  MAPPING Home

    public const int HomeMax = 11;
    public const string HomeMaxMsg = "Home phone number cannot exceed 11 digits.";

    #endregion

    #region  MAPPING WhatsApp

    public const int WhatsAppMax = 15;
    public const string WhatsAppMaxMsg = "WhatsApp number cannot exceed 15 digits.";

    #endregion

    #region  MAPPING Telegram

    public const int TelegramMax = 20;
    public const string TelegramMaxMsg = "Telegram username cannot exceed 20 characters.";

    #endregion

    #region  MAPPING Skype

    public const int SkypeMax = 50;
    public const string SkypeMaxMsg = "Skype ID cannot exceed 50 characters.";

    #endregion

    #region  MAPPING Other

    public const int OtherMax = 50;
    public const string OtherMaxMsg = "Other contact information cannot exceed 50 characters.";

    #endregion
    #region  DATA
    public const string LandlineValue = "Landline";
    public const string MobileValue = "Mobile";
    public const string WorkValue = "Work";
    public const string HomeValue = "Home";
    public const string WhatsAppValue = "WhatsApp";
    public const string TelegramValue = "Telegram";
    public const string SkypeValue = "Skype";
    public const string OtherValue = "Other";
    public const string HasColumnType = "VARCHAR";

    #endregion
}