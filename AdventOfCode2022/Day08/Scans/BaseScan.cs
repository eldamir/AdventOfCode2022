namespace AdventOfCode2022.Day08;

public abstract class BaseScan
{
    protected Map _map;
    public int[,] Results;

    public BaseScan(Map map)
    {
        Results = new int[map.Height, map.Width];
        _map = map;
    }

    public int Get(int x, int y)
    {
        return Results[y, x];
    }

    public void Set(int x, int y, int validity)
    {
        Results[y, x] = validity;
    }

    public void Run()
    {
        // Evaluate all cells individually
        Enumerable.Range(0, _map.Height).ToList().ForEach(y =>
        {
            Enumerable.Range(0, _map.Width).ToList().ForEach(x =>
            {
                var value = _map.GetValue(x, y);
                var visible = ProcessNode(x, y, value);
                Set(x, y, visible);
            });
        });
    }

    protected virtual int ProcessNode(int x, int y, int value)
    {
        return 0;
    }

    public void SetAll(int setting)
    {
        Enumerable.Range(0, _map.Height).ToList().ForEach(x =>
        {
            Enumerable.Range(0, _map.Height).ToList().ForEach(y =>
            {
                Results[y, x] = setting;
            });
        });
    }
}