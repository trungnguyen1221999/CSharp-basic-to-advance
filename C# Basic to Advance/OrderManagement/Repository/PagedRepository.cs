public class PagedRepository<T> : GenericRepository<T>, IPagedRepository<T> where T : class, IEntity
{

    public PagedRepository(List<T> items) : base(items)
    {
    }
    public async Task<PagedResult<T>> GetPagedAsync(int page, int pageSize)
    {
        var result = new PagedResult<T>(base._entities.Skip((page - 1) * pageSize).Take(pageSize), page, pageSize, base._entities.Count);
        return await Task.FromResult(result);
    }
}