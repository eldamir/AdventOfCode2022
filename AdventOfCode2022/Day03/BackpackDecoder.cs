namespace AdventOfCode2022.Day03;

public class BackpackDecoder
{
    public static List<Backpack> GetBackpacks(string data)
    {
        return data
            .Split(Environment.NewLine)
            .Select(backpackString => backpackString.ToList())
            .Select(identifierList => identifierList.Select(GetSupplyItem).ToList())
            .Select(supplyItems => new Backpack(supplyItems)).ToList();
    }

    private static SupplyItem GetSupplyItem(char identifier)
    {
        return new SupplyItem(identifier.ToString());
    }
}