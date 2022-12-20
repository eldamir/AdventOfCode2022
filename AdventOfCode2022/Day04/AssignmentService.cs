namespace AdventOfCode2022.Day04;

public class AssignmentService
{
    public static List<AssignmentPair> FindFullyContainingAssignmentPairs(List<AssignmentPair> assignmentPairs)
    {
        return assignmentPairs
            .FindAll(pair =>
                pair.Assignment1.FullyContains(pair.Assignment2)
                || pair.Assignment2.FullyContains(pair.Assignment1)
            )
            .ToList();
    }
    
    public static List<AssignmentPair> FindOverlappingAssignmentPairs(List<AssignmentPair> assignmentPairs)
    {
        return assignmentPairs
            .FindAll(pair => pair.Assignment1.Overlaps(pair.Assignment2))
            .ToList();
    }
}