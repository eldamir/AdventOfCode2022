using System.Collections;

namespace AdventOfCode2022.Day05;

public class CrateMover9001 : ICrane
{
    public void Move(StackCollection stacks, List<MoveInstruction> instructions)
    {
        Stack<ShippingContainer> tempStack = new Stack<ShippingContainer>();
        
        foreach (var instruction in instructions)
        {
            Enumerable.Repeat(0, instruction.Count).ToList()
                .ForEach(moveCount =>
                {
                    tempStack.Push(stacks.PopFromStack(instruction.From));
                });

            while (tempStack.Count > 0)
            {
                stacks.PushToStack(instruction.To, tempStack.Pop());
            }
        }
    }
}