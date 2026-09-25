public interface IPagedRepository<T>  where T : class, IEntity
{
    Task<PagedResult<T>> GetPagedAsync(int page, int pageSize);

}

