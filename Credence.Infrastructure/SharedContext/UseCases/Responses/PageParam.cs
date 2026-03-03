namespace Credence.Infrastructure.SharedContext.UseCases.Responses;

public class PageParam
{
 
        const int maxPgSize = 50;
        public int PgNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PgSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPgSize) ? maxPgSize : value;
            }
        }
        public string Term { get; set; } = string.Empty;
        public Guid Predicate { get; set; }
        public string FilterTerms { get; set; } = string.Empty;
        public string OrderBy { get; set; } = string.Empty;

    }
