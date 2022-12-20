namespace AdventOfCode2022.Day04;

public class AssignmentDecoder
{
    public static List<AssignmentPair> Decode(string data)
    {
        return data
            .Split(Environment.NewLine)
            .Select(line => line.Split(','))
            .Select(assignmentPairString => assignmentPairString.Select(s => s.Split('-').ToList()))
            .Select(assignmentPairStrings =>
                assignmentPairStrings.Select(a => new Range(int.Parse(a[0]), int.Parse(a[1]))).ToList())
            .Select(assignmentPairRanges => new AssignmentPair(assignmentPairRanges[0], assignmentPairRanges[1]))
            .ToList();
    }
}