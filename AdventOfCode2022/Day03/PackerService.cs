namespace AdventOfCode2022.Day03;

public class PackerService
{
    public static List<SupplyItem> FindDuplicates(List<Backpack> backpacks)
    {
        var duplicates = backpacks.Select(backpack =>
            backpack.Compartment1.ToHashSet()
                .Intersect(backpack.Compartment2.ToHashSet())
                .First()
            );

        return duplicates.ToList();
    }
}