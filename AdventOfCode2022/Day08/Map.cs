using Microsoft.Win32.SafeHandles;

namespace AdventOfCode2022.Day08;

public class Map
{
    private int[,] _map;
    public readonly int Width;
    public readonly int Height;
    
    public Map(int width, int height)
    {
        _map = new int[height, width];
        Width = width;
        Height = height;
    }

    public void SetValue(int x, int y, int value)
    {
        _map[y, x] = value;
    }

    public int GetValue(int x, int y)
    {
        return _map[y, x];
    }

    public Map Copy()
    {
        var copy = new Map(Width, Height);

        Enumerable.Range(0, Width).ToList().ForEach(x =>
        {
            Enumerable.Range(0, Height).ToList().ForEach(y =>
            {
                copy.SetValue(x, y, GetValue(x, y));
            });
        });
            
        return copy;
    }
}