namespace Credence.Default.DomainContext.Entities.Constants.SalesContext;

public record TransactionConst
{
    #region MAPPING Title
    public const string TitleRequired = "Title is required.";
    public const int TitleMax = 80;
    public const string TitleMaxMsg = "Title cannot exceed 80 characters.";
    #endregion

     #region ENDPOINT API
    public const string GroupRoute = "api/v1/Transactions";
    public const string GroupRouteTag = "Transactions";

    #region CREATE
    public const int CreateTransactionOrder = 1;
    public const string CreateTransaction = "CreateTransactionAsync";
    public const string CreateTransactionDesc = "Create new Transaction";
    #endregion

    #region GETBYID
    public const int GetTransactionByIdOrder = 2;
    public const string GetTransactionById = $"GetTransactionByIdAsync/{"id"}";
    public const string GetTransactionByIdDesc = "Get a Transaction.";
    #endregion

    #region UPDATE
    public const int UpdateTransactionOrder = 3;
    public const string UpdateTransaction = $"UpdateTransaction/{"id"}";
    public const string UpdateTransactionDesc = "Update a Transaction.";

    #endregion
    #region DELETE
    public const int DeleteTransactionOrder = 4;
    public const string DeleteTransaction = $"DeleteTransaction/{"id"}";
    public const string DeleteTransactionDesc = "Delete a Transaction.";
    #endregion

    #region GETALL
    public const int GetAllTransactionsOrder = 5;
    public const string GetAllTransactions = $"GetAllTransactions/{"id"}";
    public const string GetAllTransactionsDesc = "Get All Transactions.";
    #endregion
    #endregion
}