using AdventOfCode2022.Day05;

namespace Tests.Day05;

public class TestDay05_CraneStacking
{
    
    private string _data = @"    [D]    
[N] [C]    
[Z] [M] [P]
1   2   3

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2";

    [Fact]
    public void TestCanParseStackState()
    {
        var stackState = StackParser.Parse(_data);
        
        Assert.Equal(3, stackState.StackCount);
        Assert.Equal(2, stackState.GetStackCrateCount(1));
        Assert.Equal(3, stackState.GetStackCrateCount(2));
        Assert.Equal(1, stackState.GetStackCrateCount(3));
        
        Assert.Equal('N', stackState.PeekInStack(1).Identifier);
        Assert.Equal('D', stackState.PeekInStack(2).Identifier);
        Assert.Equal('P', stackState.PeekInStack(3).Identifier);
    }

    [Fact]
    public void TestCanParseInstructions()
    {
        var craneInstructions = InstructionParser.Parse(_data);

        Assert.Equal(4, craneInstructions.Count);
        
        Assert.Equal(new MoveInstruction {Count = 1, From = 2, To = 1}, craneInstructions[0]);
        Assert.Equal(new MoveInstruction {Count = 3, From = 1, To = 3}, craneInstructions[1]);
        Assert.Equal(new MoveInstruction {Count = 2, From = 2, To = 1}, craneInstructions[2]);
        Assert.Equal(new MoveInstruction {Count = 1, From = 1, To = 2}, craneInstructions[3]);
    }

    [Fact]
    public void TestCanMoveCratesCorrectlyWithCrateMover9000()
    {
        var stackState = StackParser.Parse(_data);
        var craneInstructions = InstructionParser.Parse(_data);
        var crane = new CrateMover9000();
        
        crane.Move(stackState, craneInstructions);
        
        Assert.Equal('C', stackState.PeekInStack(1).Identifier);
        Assert.Equal('M', stackState.PeekInStack(2).Identifier);
        Assert.Equal('Z', stackState.PeekInStack(3).Identifier);
        Assert.Equal("CMZ", stackState.PeekAllStacks());
    }

    [Fact]
    public void TestCanMoveCratesCorrectlyWithCrateMover9001()
    {
        var stackState = StackParser.Parse(_data);
        var craneInstructions = InstructionParser.Parse(_data);
        var crane = new CrateMover9001();
        
        crane.Move(stackState, craneInstructions);
        
        Assert.Equal('M', stackState.PeekInStack(1).Identifier);
        Assert.Equal('C', stackState.PeekInStack(2).Identifier);
        Assert.Equal('D', stackState.PeekInStack(3).Identifier);
        Assert.Equal("MCD", stackState.PeekAllStacks());
    }
}