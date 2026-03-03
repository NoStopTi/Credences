using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Credence.Infrastructure.Data;
using Credence.Infrastructure.SharedContext.UseCases.Responses;
using Credence.Domain.SharedContext.AggregateRoots.Abstractions;

namespace Credence.Infrastructure.SharedContext.Repository;

public class Repository<TAggregateRoot> : IRepository<TAggregateRoot> where TAggregateRoot : class, IAggregateRoots
{
    private readonly CredenceDbContext _CONTEXT;
    public Repository(CredenceDbContext CONTEXT)
    {
        _CONTEXT = CONTEXT;
    }
    public void Add(TAggregateRoot entity)
    {
        _CONTEXT.Set<TAggregateRoot>().Add(entity);
    }
    public void Update(TAggregateRoot entity)
    {
        _CONTEXT.Entry(entity).CurrentValues.SetValues(entity);
        _CONTEXT.Set<TAggregateRoot>().Update(entity);
    }

    public void Delete(TAggregateRoot entity)
    {
        _CONTEXT.Set<TAggregateRoot>().Remove(entity);
    }
    public async Task<int> GetCount(Expression<Func<TAggregateRoot, bool>> predicate)
    {
        return await _CONTEXT.Set<TAggregateRoot>().Where(predicate).AsNoTracking().CountAsync();
    }
    public IQueryable<TAggregateRoot> Get(Expression<Func<TAggregateRoot, bool>> predicate = null!,
                                                                 Func<IQueryable<TAggregateRoot>,
                                                                 IIncludableQueryable<TAggregateRoot,
                                                                 object>> include = null!,
                                                                 Expression<Func<TAggregateRoot, TAggregateRoot>> selector = null!, 
                                                                 Func<IQueryable<TAggregateRoot>, 
                                                                 IOrderedQueryable<TAggregateRoot>> orderBy = null!,
                                                                 Expression<Func<TAggregateRoot, bool>> termPredicate = null!,
                                                                 bool disableTracking = true)
    {
        IQueryable<TAggregateRoot> query = _CONTEXT.Set<TAggregateRoot>();

        if (disableTracking)
            query = query.AsNoTracking();

        if (termPredicate != null)
            query = query.Where(termPredicate);

        if (predicate != null)
            query = query.Where(predicate);

        if (include != null)
            query = include(query);

        if (orderBy != null)
            return query = orderBy(query).Select(selector);

        return query;

    }
    public virtual async Task<TAggregateRoot> GetByPredicate(Expression<Func<TAggregateRoot, bool>> predicate = null!, 
                                                           Func<IQueryable<TAggregateRoot>, 
                                                           IIncludableQueryable<TAggregateRoot, object>> include = null!, 
                                                           Expression<Func<TAggregateRoot, TAggregateRoot>> selector = null!, 
                                                           Func<IQueryable<TAggregateRoot>, 
                                                           IOrderedQueryable<TAggregateRoot>> ordeBy = null!, 
                                                           bool disableTracking = true)
    {

        IQueryable<TAggregateRoot> query = _CONTEXT.Set<TAggregateRoot>();

        if (disableTracking)
            query = query.AsNoTracking();

        if (predicate != null)
            query = query.Where(predicate);

        if (include != null)
            query = include(query);

        if (ordeBy != null)
            return await ordeBy(query).Select(selector).SingleOrDefaultAsync() ?? null!;
        else
            return await query.Select(selector).SingleOrDefaultAsync() ?? null!;


    }
    public async Task<PagedResponse<List<TAggregateRoot>>> GetPaged(PageParam parameters, 
                                                        Expression<Func<TAggregateRoot, bool>> predicate = null!, 
                                                        Func<IQueryable<TAggregateRoot>, 
                                                        IIncludableQueryable<TAggregateRoot, object>> include = null!, 
                                                        Expression<Func<TAggregateRoot, TAggregateRoot>> selector = null!, 
                                                        Func<IQueryable<TAggregateRoot>, 
                                                        IOrderedQueryable<TAggregateRoot>> orderBy = null!, 
                                                        Expression<Func<TAggregateRoot, bool>> termPredicate = null!, 
                                                        bool noTraking = true)
    {
        IQueryable<TAggregateRoot> query = _CONTEXT.Set<TAggregateRoot>();

        if (noTraking)
            query = query.AsNoTracking();

        if (termPredicate != null)
            query = query.Where(termPredicate);

        if (predicate != null)
            query = query.Where(predicate);

        if (include != null)
            query = include(query);

        if (orderBy != null)
            query = orderBy(query).Select(selector);

        var totalCount = await query.CountAsync();

        var pagination = await query.Skip((parameters.PgNumber - 1) * parameters.PgSize).Take(parameters.PgSize).ToListAsync();

        return new PagedResponse<List<TAggregateRoot>>(pagination, totalCount,parameters.PgNumber, parameters.PgSize);

    }

}