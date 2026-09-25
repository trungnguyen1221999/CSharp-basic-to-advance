public abstract class GenericRepository<T> : IRepository<T> where T : class, IEntity
{
    protected List<T> _entities;

    public GenericRepository(List<T> entities)
    {
        _entities = entities;
    }
    public Task AddAsync(T entity)
    {
        _entities.Add(entity);
        return Task.CompletedTask;
    }

    public Task<int> CountAsync()
    {
        return Task.FromResult(_entities.Count);
    }

    public Task DeleteAsync(Guid id)
    {
       _entities.RemoveAll(e => e.Id == id);
       return Task.CompletedTask;
    }

    public Task<IEnumerable<T>?> FindAsync(Predicate<T> predicate)
    {
        var result = _entities.FindAll(predicate);
        return Task.FromResult<IEnumerable<T>?>(result);
    }

    public Task<IEnumerable<T>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<T>>(_entities);
    }

    public Task<T?> GetByIdAsync(Guid id)
    {
        var entity = _entities.FirstOrDefault(e => e.Id == id);
        return Task.FromResult<T?>(entity);
    }

    public Task UpdateAsync(T entity)
    {
        var index = _entities.FindIndex(e => e.Id == entity.Id);
        if (index >= 0)
        {
            _entities[index] = entity;
        }
        return Task.CompletedTask;
    }

    
}