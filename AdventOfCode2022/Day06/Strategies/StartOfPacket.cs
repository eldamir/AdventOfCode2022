namespace AdventOfCode2022.Day06;

public class StartOfPacket : IStrategy
{
    private Queue<char> _queue = new();
    protected int _maxQueueSize = 4;
    private int _itemsRead = 0;
    
    public void Clear()
    {
        _queue.Clear();
        _itemsRead = 0;
    }

    public void Add(char item)
    {
        _queue.Enqueue(item);
        _itemsRead++;
        
        if (_queue.Count > _maxQueueSize)
        {
            _queue.Dequeue();
        }
    }

    public bool IsInputSatisfied()
    {
        return _queue.Count >= _maxQueueSize;
    }

    public ScanResult Match()
    {
        if (_queue.ToList().Distinct().Count() == _queue.Count)
        {
            return new ScanResult { Count = _itemsRead };
        }

        return null;
    }
}