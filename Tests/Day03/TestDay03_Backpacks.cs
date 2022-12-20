using AdventOfCode2022.Day03;

namespace Tests.Day03;

public class TestDay03_Backpacks
{
    [Fact]
    public void TestCanRePackBackpack()
    {
        var backpack = new Backpack(new List<SupplyItem>
        {
            new("a"),
            new("b"),
            new("c"),
            new("a"),
        });

        Assert.Contains(new SupplyItem("a"), backpack.Compartment1);
        Assert.Contains(new SupplyItem("b"), backpack.Compartment1);
        Assert.Contains(new SupplyItem("c"), backpack.Compartment2);
        Assert.Contains(new SupplyItem("a"), backpack.Compartment2);
    }

    [Fact]
    public void TestCanFindItemThatAppearsInEachCompartment()
    {
        string data = @"abcapo
bcdiob";

        var backpacks = BackpackDecoder.GetBackpacks(data);
        var duplicates = PackerService.FindDuplicates(backpacks);

        Assert.Equal(2, duplicates.Count);

        Assert.Contains(new SupplyItem("a"), duplicates);
        Assert.Contains(new SupplyItem("b"), duplicates);
    }

    [Fact]
    public void TestCanSumPrioritiesOfItemsThatAppearTwice()
    {
        string data = @"vJrwpWtwJgWrhcsFMMfFFhFp
jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
PmmdzqPrVvPwwTWBwg
wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
ttgJtRGJQctTZtZT
CrZsJsPPZsGzwwsLwLmpwMDw";

        var backpacks = BackpackDecoder.GetBackpacks(data);
        var duplicates = PackerService.FindDuplicates(backpacks);
        var sum = duplicates.Sum(i => i.Priority);

        Assert.Equal(157, sum);
    }
}