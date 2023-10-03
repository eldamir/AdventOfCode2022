namespace AdventOfCode2022.Day08;

public class VisibilityScan : BaseScan
{
    public VisibilityScan(Map map): base(map)
    {
        SetAll(1);
    }

    public int CountValid()
    {
        int sum = 0;
        Enumerable.Range(0, _map.Width).ToList().ForEach(x =>
        {
            Enumerable.Range(0, _map.Height).ToList().ForEach(y =>
            {
                if (IsValid(x, y))
                {
                    sum++;
                }
            });
        });
            
        return sum;
    }

    public bool IsValid(int x, int y)
    {
        return Get(x, y) == 1;
    }

    public void Run()
    {
        SetAll(0);
        base.Run();
    }

    protected override int ProcessNode(int x, int y, int value)
    {
        return ProcessNode(x, y, value, CheckHeight);
    }

    private bool CheckHeight(int scannedValue, int nodeValue)
    {
        return scannedValue >= nodeValue;
    }

    private int ProcessNode(int x, int y, int value, Func<int, int, bool> condition)
    {
        if (ScanHorizontal(x, y, value, true, condition) || ScanHorizontal(x, y, value, false, condition) ||
            ScanVertical(x, y, value, true, condition) || ScanVertical(x, y, value, false, condition))
            return 1;
        return 0;
    }

    private bool ScanHorizontal(int x, int y, int value, bool isRightDirection, Func<int, int, bool> condition)
    {
        int direction = isRightDirection ? 1 : -1;
        for (int scanX = x + direction; scanX >= 0 && scanX < _map.Width; scanX += direction)
        {
            if (condition(_map.GetValue(scanX, y), value))
                return false;
        }
        return true;
    }

    private bool ScanVertical(int x, int y, int value, bool isUpDirection, Func<int, int, bool> condition)
    {
        int direction = isUpDirection ? -1 : 1;
        for (int scanY = y + direction; scanY >= 0 && scanY < _map.Height; scanY += direction)
        {
            if (condition(_map.GetValue(scanY, y), value))
                return false;
        }
        return true;
    }
}