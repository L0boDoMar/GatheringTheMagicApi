using GatheringTheMagic.Domain.Entities;
using GatheringTheMagic.Domain.Interfaces;
using GatheringTheMagic.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace GatheringTheMagic.Persistence.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext Context;

    public BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    public void Create(T entity)
    {
       entity.DateCreated = DateTime.Now;
       Context.Add(entity);
    }

    public void Update(T entity)
    {
        entity.DateModified = DateTime.Now;
        Context.Update(entity);
    }

    public void Delete(T entity)
    {
       entity.DateDeleted = DateTime.Now;
        Context.Remove(entity);
    }

    public async Task<T> Get(Guid id, CancellationToken cancellationToken)
    {
        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken)
    {
       return await Context.Set<T>().ToListAsync(cancellationToken);
    }
}
