public class PagedResult<T>
{
    public IEnumerable<T> Items { get;  private set; }
    public int TotalCount { get; private set; }

    public int Page { get; private set; }
    public int PageSize { get; private set; }

    public int TotalPages { get; private     set; }
    public PagedResult(IEnumerable<T> items, int page, int pageSize, int totalCount)
    {
        Items = items;
        TotalCount = totalCount;
        Page = page;
        PageSize = pageSize;
        TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
    }
}