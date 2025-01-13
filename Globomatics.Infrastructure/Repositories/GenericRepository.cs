using Globomatics.Infrastructure.Data;

namespace Globomatics.Infrastructure.Repositories;

public abstract class GenericRepository<T>(GlobomanticsContext context) : IRepository<T> where T : class
{
    protected GlobomanticsContext Context = context;

    public virtual T Add(T entity)
    {
        T? addedEntity = Context.Add(entity).Entity;

        return addedEntity;
    }

    public virtual IEnumerable<T> All()
    {
        List<T>? all = Context.Set<T>().ToList();

        return all;
    }

    public virtual T? Get(Guid id)
    {
        return Context.Find<T>(id);
    }

    public virtual void SaveChanges()
    {
        Context.SaveChanges();
    }

    public virtual T Update(T entity)
    {
        return Context.Update(entity).Entity;
    }
}