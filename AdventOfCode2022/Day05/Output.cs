namespace AdventOfCode2022.Day05;

public class Output
{
    public static void Main()
    {
        var stackState = StackParser.Parse(Input.Data);
        var craneInstructions = InstructionParser.Parse(Input.Data);
        stackState.ApplyInstructions(craneInstructions);
        Console.WriteLine($"The top of the stacks read: {stackState.PeekAllStacks()}");
    }
}