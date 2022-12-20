namespace AdventOfCode2022.Day03;

public class PackerService
{
    public static List<SupplyItem> FindDuplicates(List<Backpack> backpacks)
    {
        var duplicates = backpacks.Select(backpack =>
            backpack.Compartment1.Intersect(backpack.Compartment2)
                .First()
            );

        return duplicates.ToList();
    }

    public static List<SupplyItem> FindGroupBadges(List<Backpack> backpacks)
    {
        return backpacks.Chunk(3).Select(FindGroupBadge).ToList();
    }

    private static SupplyItem FindGroupBadge(IEnumerable<Backpack> backpacks)
    {
        return backpacks
            .Select(b => b.AllCompartments)
            .Aggregate((acc, instance) => acc.Intersect(instance).ToList())
            .First();
    }
}