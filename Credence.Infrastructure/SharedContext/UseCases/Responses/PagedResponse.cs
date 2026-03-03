using System.Text.Json.Serialization;
using Credence.Default.ApiContext.Configurations;

namespace Credence.Infrastructure.SharedContext.UseCases.Responses;

public class PagedResponse<TData>
{
    private readonly int _code;

    [JsonConstructor]
    public PagedResponse(
        TData data,
        int totalCount,
        int currentPage,
        int pageSize = ApiSettings.DefaultPageSize

        )
    {
        Data = data;
        TotalCount = totalCount;
        CurrentPage = currentPage;
        PageSize = pageSize;
        _code = ApiSettings.DefaultStatusCode;
    }

    public PagedResponse(
        TData? data,
        int code = ApiSettings.DefaultStatusCode,
        string? message = null
        )
    {
        Data = data;
        Message = message;
        _code = code;
    }

    public int CurrentPage { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalPages / (double)PageSize);
    public int PageSize { get; set; } = ApiSettings.DefaultPageSize;
    public int TotalCount { get; set; }
    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= 200 and <= 299;
    // public static async Task<PagedResponse<TData>> ToPagedList(IQueryable<TData> source, int currentPg, int pgSize)
    // {
    //     var count = source.Count();
    //     var items = await source.Skip((currentPg - 1) * pgSize).Take(pgSize).ToListAsync();
    //     return new PagedResponse<Response<TData>>(items, count, currentPg, pgSize);
    // }

}

