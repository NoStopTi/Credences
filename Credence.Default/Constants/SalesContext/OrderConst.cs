namespace Credence.Default.DomainContext.Entities.Constants.SalesContext;

public record OrderConst
{
    #region MAPPING

    public const string ToTable = "Orders";
    public const string _CHAR = "CHAR";
    public const string _VARCHAR = "VARCHAR";
    public const string _SMALLINT = "SMALLINT";
    public const string _DATETIME2 = "DATETIME2";

    public const int _MaxNumber = 8;
    public const int _MaxExternalReference = 60;
    public const int _MaxUserId = 160;

    #endregion

    #region ERRORS
    public const string InvalidEOrderStatus = "Status invalid!";
    #endregion

    // #region MAPPING Description
    // public const int DescriptionMax = 255;
    // public const string DescriptionMaxMsg = "Description cannot exceed 255 characters.";
    // #endregion


    // #region ENDPOINT API
    // public const string GroupRoute = "api/v1/categories";
    // public const string GroupRouteTag = "Categories";

    // #region CREATE
    // public const int CreateCategoryOrder = 1;
    // public const string CreateCategory = "CreateCategoryAsync";
    // public const string CreateCategoryDesc = "Create new category";
    // #endregion

    // #region GETBYID
    // public const int GetCategoryByIdOrder = 2;
    // public const string GetCategoryById = $"GetCategoryByIdAsync/{"id"}";
    // public const string GetCategoryByIdDesc = "Get a category.";
    // #endregion

    // #region UPDATE
    // public const int UpdateCategoryOrder = 3;
    // public const string UpdateCategory = $"UpdateCategory/{"id"}";
    // public const string UpdateCategoryDesc = "Update a category.";

    // #endregion
    // #region DELETE
    // public const int DeleteCategoryOrder = 4;
    // public const string DeleteCategory = $"DeleteCategory/{"id"}";
    // public const string DeleteCategoryDesc = "Delete a category.";
    // #endregion

    // #region GETALL
    // public const int GetAllCategoriesOrder = 5;
    // public const string GetAllCategories = $"GetAllCategories/{"id"}";
    // public const string GetAllCategoriesDesc = "Get All Categories.";
    // #endregion

    // #endregion

}