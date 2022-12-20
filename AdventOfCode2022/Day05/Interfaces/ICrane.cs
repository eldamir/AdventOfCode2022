namespace AdventOfCode2022.Day05;

public interface ICrane
{
    public void Move(StackCollection stacks, List<MoveInstruction> instructions);
}