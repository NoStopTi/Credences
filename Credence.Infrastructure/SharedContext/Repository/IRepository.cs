using System.Linq.Expressions;
using Credence.Domain.SharedContext.AggregateRoots.Abstractions;
using Credence.Infrastructure.SharedContext.UseCases.Responses;
using Microsoft.EntityFrameworkCore.Query;

namespace Credence.Infrastructure.SharedContext.Repository;

public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoots
{
    void Add(TAggregateRoot entity);
    void Update(TAggregateRoot entity);
    void Delete(TAggregateRoot entity);
    Task<int> GetCount(Expression<Func<TAggregateRoot, bool>> predicate);
    IQueryable<TAggregateRoot> Get(
                            Expression<Func<TAggregateRoot, bool>> predicate = null!,
                            Func<IQueryable<TAggregateRoot>, IIncludableQueryable<TAggregateRoot, object>> include = null!,
                            Expression<Func<TAggregateRoot, TAggregateRoot>> selector = null!,
                            Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>> orderBy = null!,
                            Expression<Func<TAggregateRoot, bool>> termPredicate = null!,
                            bool disableTracking = true
    );
    Task<TAggregateRoot> GetByPredicate(Expression<Func<TAggregateRoot, bool>> predicate = null!, Func<IQueryable<TAggregateRoot>, IIncludableQueryable<TAggregateRoot, object>> include = null!, Expression<Func<TAggregateRoot, TAggregateRoot>> selector = null!, Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>> ordeBy = null!, bool disableTracking = true);
    Task<PagedResponse<List<TAggregateRoot>>> GetPaged(
        PageParam parameters,
        Expression<Func<TAggregateRoot, bool>> predicate = null!,
        Func<IQueryable<TAggregateRoot>, IIncludableQueryable<TAggregateRoot, object>> include = null!,
        Expression<Func<TAggregateRoot, TAggregateRoot>> selector = null!,
        Func<IQueryable<TAggregateRoot>, IOrderedQueryable<TAggregateRoot>> orderBy = null!,
        Expression<Func<TAggregateRoot, bool>> termPredicate = null!,
        bool noTraking = true
    );
}
