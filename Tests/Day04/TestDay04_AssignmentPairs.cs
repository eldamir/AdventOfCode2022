using AdventOfCode2022.Day04;

namespace Tests.Day04;

public class TestDay04_AssignmentPairs
{
    private string _data = @"2-4,6-8
2-3,4-5
5-7,7-9
2-8,3-7
6-6,4-6
2-6,4-8";

    [Fact]
    public void TestFindPairsContainingOthers()
    {
        var assignmentPairs = AssignmentDecoder.Decode(_data);
        var fullyContainingAssignments = AssignmentService.FindFullyContainingAssignmentPairs(assignmentPairs);
        
        Assert.Equal(2, fullyContainingAssignments.Count);
    }
    
    [Fact]
    public void TestFindPairsOverlappingOthers()
    {
        var assignmentPairs = AssignmentDecoder.Decode(_data);
        var fullyContainingAssignments = AssignmentService.FindOverlappingAssignmentPairs(assignmentPairs);
        
        Assert.Equal(4, fullyContainingAssignments.Count);
    }
}