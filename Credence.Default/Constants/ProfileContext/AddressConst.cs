
namespace Credence.Default.DomainContext.Entities.Constants.ProfileContext;

public record AddressConst
{
    #region COMMON
    public const string HasColumnType = "VARCHAR";
 
    //PF_ == ProFile
    public const string ToTable = "PF_Addresses";
       
    #endregion

    #region MAPPING street

    public const string Required = "this property is required.";
    public const string StreetRequired = "Street is required.";
    public const int StreetMax = 200;
    public const string StreetMaxMsg = " Street cannot exceed 200 characters.";
    #endregion

    #region MAPPING Number


    public const string NumberRequired = "Number is required.";
    public const int NumberMax = 20;
    public const string NumberMaxMsg = "Number cannot exceed 20 characters.";
    #endregion

    #region MAPPING Complement


    public const string ComplementRequired = "Complement is required.";
    public const int ComplementMax = 100;
    public const string ComplementMaxMsg = " Complement cannot exceed 100 characters.";
    #endregion

    #region MAPPING Neighborhood


    public const string NeighborhoodRequired = "Neighborhood is required.";
    public const int NeighborhoodMax = 100;
    public const string NeighborhoodMaxMsg = " Neighborhood cannot exceed 100 characters.";
    #endregion

    #region MAPPING City


    public const string CityRequired = "City is required.";
    public const int CityMax = 100;
    public const string CityMaxMsg = " City cannot exceed 100 characters.";
    #endregion

    #region MAPPING State


    public const string StateRequired = "State is required.";
    public const int StateMax = 50;
    public const string StateMaxMsg = "State cannot exceed 50 characters.";
    #endregion

    #region MAPPING ZipCode


    public const string ZipCodeRequired = "ZipCode is required.";
    public const int ZipCodeMax = 20;
    public const string ZipCodeMaxMsg = "ZipCode cannot exceed 20 characters.";
    #endregion

    #region MAPPING Country


    public const string CountryRequired = "Country is required.";
    public const string CountryHasDefaultValue = "Brasil";
    public const int CountryMax = 50;
    public const string CountryMaxMsg = "Country cannot exceed 50 characters.";

    #endregion
}
