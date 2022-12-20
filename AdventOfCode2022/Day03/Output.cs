namespace AdventOfCode2022.Day03;

public class Output
{
    public static void Main()
    {
        var sum = PackerService.FindDuplicates(BackpackDecoder.GetBackpacks(Input.Data)).Sum(i => i.Priority);
        Console.WriteLine($"Priority sum of duplicates in bags: {sum}");
    }
}