namespace AdventOfCode2022.Day05;

public class CrateMover9000 : ICrane
{
    public void Move(StackCollection stacks, List<MoveInstruction> instructions)
    {
        foreach (var instruction in instructions)
        {
            Enumerable.Repeat(0, instruction.Count).ToList()
                .ForEach(moveCount => stacks.Move(instruction.From, instruction.To));
        }
    }
}