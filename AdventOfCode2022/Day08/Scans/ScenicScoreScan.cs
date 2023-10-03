namespace AdventOfCode2022.Day08;

public class ScenicScoreScan : BaseScan
{
    public ScenicScoreScan(Map map) : base(map)
    {
    }

    private bool CalculateScenicScore(int scannedValue, int nodeValue)
    {
        return scannedValue > nodeValue;
    }

    protected override int ProcessNode(int x, int y, int value)
    {
        var scanRight = ScanHorizontal(x, y, value, true);
        var scanLeft = ScanHorizontal(x, y, value, false);
        var scanUp = ScanVertical(x, y, value, true);
        var scanDown = ScanVertical(x, y, value, false);
        return scanRight * scanLeft *
               scanUp * scanDown;
    }

    private int ScanHorizontal(int x, int y, int value, bool isRightDirection)
    {
        int direction = isRightDirection ? 1 : -1;
        int count = 0;
        for (int scanX = x + direction; scanX >= 0 && scanX < _map.Width; scanX += direction)
        {
            count++;
            if (_map.GetValue(scanX, y) >= value)
            {
                break;
            }
        }
        return count;
    }

    private int ScanVertical(int x, int y, int value, bool isUpDirection)
    {
        int direction = isUpDirection ? -1 : 1;
        int count = 0;
        for (int scanY = y + direction; scanY >= 0 && scanY < _map.Height; scanY += direction)
        {
            count++;
            if (_map.GetValue(x, scanY) >= value)
            {
                break;
            }
        }

        return count;
    }
}