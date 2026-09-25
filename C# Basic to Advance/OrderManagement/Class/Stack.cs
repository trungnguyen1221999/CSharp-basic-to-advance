public class Stack<T> 
{
    private readonly List<T> _stack = new ();
    public void Push(T item)
    {
        _stack.Add(item);
    }

    public T Pop()
    {
        if (IsEmpty)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        var item = _stack[Count - 1];
        _stack.RemoveAt(Count - 1);
        return item;
    }

    public T Peek()
    {
        return _stack[Count - 1];
    }

    public int Count => _stack.Count;
    public bool IsEmpty => Count == 0;
}