public class MinMax<T> where T : IComparable<T>
{
    private readonly IEnumerable<T> _items;

    public MinMax(IEnumerable<T> items)
    {
        EnsureListNotEmpty(items);
        _items = items;
    }
    public T FindMin ()
    {
        var min = _items.First();
        foreach (var item in _items)
        {
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }
        }
        return min;
    }
    public T FindMax()
    {
        var max = _items.First();
        foreach (var item in _items)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }
        return max;
    }

    private void EnsureListNotEmpty(IEnumerable<T> items)
    {
        if (!items.Any())
        {
            throw new InvalidOperationException("The collection is empty.");
        }
    }
}