namespace AdventOfCode2022.Day05;

public class Output
{
    public static void Main()
    {
        var stackState1 = StackParser.Parse(Input.Data);
        var craneInstructions1 = InstructionParser.Parse(Input.Data);
        var crane1 = new CrateMover9000();
        crane1.Move(stackState1, craneInstructions1);

        Console.WriteLine(
            $"After moving crates with CrateMover9000, the top of the stacks read: {stackState1.PeekAllStacks()}");
        
        var stackState2 = StackParser.Parse(Input.Data);
        var craneInstructions2 = InstructionParser.Parse(Input.Data);
        var crane2 = new CrateMover9001();
        crane2.Move(stackState2, craneInstructions2);

        Console.WriteLine(
            $"After moving crates with CrateMover9001, the top of the stacks read: {stackState2.PeekAllStacks()}");
    }
}