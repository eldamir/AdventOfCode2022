namespace AdventOfCode2022.Day05;

public class MoveInstruction : IEquatable<MoveInstruction>
{
    public int Count { get; set; }
    public int From { get; set; }
    public int To { get; set; }

    public bool Equals(MoveInstruction? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return Count == other.Count && From == other.From && To == other.To;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((MoveInstruction)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Count, From, To);
    }
}