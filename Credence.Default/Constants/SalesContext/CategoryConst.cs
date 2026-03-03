namespace Credence.Default.DomainContext.Entities.Constants.SalesContext;

public record CategoryConst
{
    #region MAPPING Title
    public const string TitleRequired = "Title is required.";
    public const int TitleMax = 80;
    public const string TitleMaxMsg = "Title cannot exceed 80 characters.";
    #endregion

    #region MAPPING Description
    public const int DescriptionMax = 255;
    public const string DescriptionMaxMsg = "Description cannot exceed 255 characters.";
    #endregion


    #region ENDPOINT API
    public const string GroupRoute = "api/v1/categories";
    public const string GroupRouteTag = "Categories";

    #region CREATE
    public const int CreateCategoryOrder = 1;
    public const string CreateCategory = "CreateCategoryAsync";
    public const string CreateCategoryDesc = "Create new category";
    #endregion

    #region GETBYID
    public const int GetCategoryByIdOrder = 2;
    public const string GetCategoryById = $"GetCategoryByIdAsync/{"id"}";
    public const string GetCategoryByIdDesc = "Get a category.";
    #endregion

    #region UPDATE
    public const int UpdateCategoryOrder = 3;
    public const string UpdateCategory = $"UpdateCategory/{"id"}";
    public const string UpdateCategoryDesc = "Update a category.";

    #endregion
    #region DELETE
    public const int DeleteCategoryOrder = 4;
    public const string DeleteCategory = $"DeleteCategory/{"id"}";
    public const string DeleteCategoryDesc = "Delete a category.";
    #endregion

    #region GETALL
    public const int GetAllCategoriesOrder = 5;
    public const string GetAllCategories = $"GetAllCategories/{"id"}";
    public const string GetAllCategoriesDesc = "Get All Categories.";
    #endregion

    #endregion

}