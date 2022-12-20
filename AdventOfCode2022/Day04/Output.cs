namespace AdventOfCode2022.Day04;

public class Output
{
    public static void Main()
    {
        var containingPairs =
            AssignmentService.FindFullyContainingAssignmentPairs(AssignmentDecoder.Decode(Input.Data));
        Console.WriteLine($"Pairs where one fully contains the other: {containingPairs.Count}");
        
        var overlappingPairs =
            AssignmentService.FindOverlappingAssignmentPairs(AssignmentDecoder.Decode(Input.Data));
        Console.WriteLine($"Pairs where one fully contains the other: {overlappingPairs.Count}");
    }
}