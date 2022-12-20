namespace AdventOfCode2022.Day04;

public struct Range
{
    public int Min { get; private set; }
    public int Max { get; private set; } 
       
    public Range(int min, int max)
    {
        Min = min;
        Max = max;
    }
    
    public bool FullyContains(Range other)
    {
        return Expand().IsSupersetOf(other.Expand());
    }
    
    public bool Overlaps(Range other)
    {
        return Expand().Overlaps(other.Expand());
    }

    private HashSet<int> Expand()
    {
        HashSet<int> result = new();
        for (int i = Min; i <= Max; i++)
        {
            result.Add(i);

        }

        return result;
    }
}