using Microsoft.Win32.SafeHandles;

namespace AdventOfCode2022.Day08;

public class Map
{
    private int[,] _map;
    private Validity[,] _validMap;
    private int _width;
    private int _height;
    
    public Map(int width, int height)
    {
        _map = new int[height, width];
        _validMap = new Validity[height, width];
        _width = width;
        _height = height;
        SetAll(Validity.Valid);
    }

    public void SetValue(int x, int y, int value)
    {
        _map[y, x] = value;
    }

    public int GetValue(int x, int y)
    {
        return _map[y, x];
    }

    public bool IsValid(int x, int y)
    {
        return _validMap[y, x] == Validity.Valid;
    }

    public void SetValidity(int x, int y, Validity validity)
    {
        _validMap[y, x] = validity;
    }

    public Map Copy()
    {
        var copy = new Map(_width, _height);

        Enumerable.Range(0, _width).ToList().ForEach(x =>
        {
            Enumerable.Range(0, _height).ToList().ForEach(y =>
            {
                copy.SetValue(x, y, GetValue(x, y));
            });
        });
            
        return copy;
    }
    
    public void SetAll(Validity setting)
    {
        int sum = 0;
        Enumerable.Range(0, _width).ToList().ForEach(x =>
        {
            Enumerable.Range(0, _height).ToList().ForEach(y =>
            {
                _validMap[y, x] = setting;
            });
        });
    }

    public int CountValid()
    {
        int sum = 0;
        Enumerable.Range(0, _width).ToList().ForEach(x =>
        {
            Enumerable.Range(0, _height).ToList().ForEach(y =>
            {
                if (IsValid(x, y))
                {
                    sum++;
                }
            });
        });
            
        return sum;
    }

    public void InvalidateObstructed()
    {
        SetAll(Validity.Invalid);
        
        // Evaluate all cells individually
        Enumerable.Range(0, _height).ToList().ForEach(y =>
        {
            Enumerable.Range(0, _width).ToList().ForEach(x =>
            {
                var value = GetValue(x, y);
                var visible = ScanAllSides(x, y, value);
                SetValidity(x, y, visible ? Validity.Valid : Validity.Invalid);
            });
        });
    }

        private bool ScanAllSides(int x, int y, int value)
    {
        if (ScanHorizontal(x, y, value, true) || ScanHorizontal(x, y, value, false) ||
            ScanVertical(x, y, value, true) || ScanVertical(x, y, value, false))
            return true;
        return false;
    }

    private bool ScanHorizontal(int x, int y, int value, bool isRightDirection)
    {
        int direction = isRightDirection ? 1 : -1;
        for (int scanX = x + direction; scanX >= 0 && scanX < _width; scanX += direction)
        {
            if (GetValue(scanX, y) >= value)
                return false;
        }
        return true;
    }

    private bool ScanVertical(int x, int y, int value, bool isUpDirection)
    {
        int direction = isUpDirection ? -1 : 1;
        for (int scanY = y + direction; scanY >= 0 && scanY < _height; scanY += direction)
        {
            if (GetValue(x, scanY) >= value)
                return false;
        }
        return true;
    }
}