namespace AdventOfCode2022.Day03;

public class SupplyItem : IEquatable<SupplyItem>
{
    private string _identifier;
    public int Priority => GetPriority();

    public SupplyItem(string identifier)
    {
        _identifier = identifier;
    }

    private int GetPriority()
    {
        char identifier = _identifier.ToCharArray()[0];
        int identifierOrd = (int)identifier;
        bool isUpperCase = identifierOrd >= 65 && identifierOrd <= 90;

        return isUpperCase ? identifierOrd - 64 + 26 : identifier - 96;
    }

    #region Equatable members

    public bool Equals(SupplyItem? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return _identifier == other._identifier;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((SupplyItem)obj);
    }

    public override int GetHashCode()
    {
        return _identifier.GetHashCode();
    }

    #endregion
}