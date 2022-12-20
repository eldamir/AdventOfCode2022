namespace AdventOfCode2022.Day03;

public class Output
{
    public static void Main()
    {
        var duplicatesSum = PackerService.FindDuplicates(BackpackDecoder.GetBackpacks(Input.Data)).Sum(i => i.Priority);
        Console.WriteLine($"Priority sum of duplicates in backpacks: {duplicatesSum}");
        
        var badgesSum = PackerService.FindGroupBadges(BackpackDecoder.GetBackpacks(Input.Data)).Sum(i => i.Priority);
        Console.WriteLine($"Priority sum of badges in backpacks: {badgesSum}");
    }
}