namespace AdventOfCode2022.Day04;

public class Output
{
    public static void Main()
    {
        var containingPairs =
            AssignmentService.FindFullyOverlappingAssignmentPairs(AssignmentDecoder.Decode(Input.Data));
        Console.WriteLine($"Pairs where one fully contains the other: {containingPairs.Count}");
    }
}