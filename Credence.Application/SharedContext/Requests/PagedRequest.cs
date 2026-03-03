using Credence.Default.ApiContext.Configurations;

namespace Credence.Application.SharedContext.Requests;

public abstract class PagedRequest : Request
{
   public int PageNumber { get; set; } = ApiSettings.DefaultPageNumber;
   public int PageSize { get; set; } = ApiSettings.DefaultPageSize;

   public int DefaultPagination() => (PageNumber - 1) * PageSize;

}