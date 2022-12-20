using Microsoft.VisualBasic;

namespace AdventOfCode2022.Day05;

public class StackCollection
{
    private List<Stack<ShippingContainer>> _stacks;
    public int StackCount => _stacks.Count;

    public StackCollection(int stackCount)
    {
        _stacks = new();

        for (int i = 0; i < stackCount; i++)
        {
            _stacks.Add(new Stack<ShippingContainer>());
        }
    }

    /// <summary>
    /// Get the numbered stack
    /// </summary>
    /// <param name="number">The number of the stack. Note that the number is 1-indexed</param>
    /// <returns></returns>
    public Stack<ShippingContainer> GetStack(int number)
    {
        return _stacks[number - 1];
    }
    
    public ShippingContainer PeekInStack(int number)
    {
        return GetStack(number).Peek();
    }

    public string PeekAllStacks()
    {
        List<string> chars = new List<string>();
        for (int i = 0; i < StackCount; i++)
        {
            chars.Add(PeekInStack(i + 1).Identifier.ToString());
        }

        return Strings.Join(chars.ToArray(), "");
    }

    public ShippingContainer PopFromStack(int number)
    {
        return GetStack(number).Pop();
    }
    
    public void PushToStack(int number, ShippingContainer crate)
    {
        GetStack(number).Push(crate);
    }

    public void Move(int from, int to)
    {
        var crate = GetStack(from).Pop();
        PushToStack(to, crate);
    }
    
    public int GetStackCrateCount(int number)
    {
        return GetStack(number).Count;
    }
}