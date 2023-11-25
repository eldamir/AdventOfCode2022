using System.ComponentModel;
using AdventOfCode2022.Day09;
using AdventOfCode2022.Day09.RopeBridge;

namespace Tests.Day09;

public class TestDay09_RopeBridge
{
    private readonly string _commandString = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";
    
    [Fact]
    public void TestCanParseInput()
    {
        InputScanner inputScanner = new InputScanner();
        InstructionSet instructions = inputScanner.Scan(_commandString);
        
        Assert.Equal(8, instructions.Commands.Count);
        Assert.Equal(Direction.Right, instructions.Commands[0].Direction);
        Assert.Equal(4, instructions.Commands[0].Steps);
        Assert.Equal(Direction.Up, instructions.Commands[1].Direction);
        Assert.Equal(4, instructions.Commands[1].Steps);
        Assert.Equal(Direction.Left, instructions.Commands[2].Direction);
        Assert.Equal(3, instructions.Commands[2].Steps);
        Assert.Equal(Direction.Right, instructions.Commands[7].Direction);
        Assert.Equal(2, instructions.Commands[7].Steps);
    }

    [Fact]
    public void TestCanTrackTailMovement()
    {
        InputScanner inputScanner = new InputScanner();
        InstructionSet instructions = inputScanner.Scan(_commandString);
        RopeWorld world = new RopeWorld();
        world.ExecuteInstructions(instructions);
    
        int uniqueCoordinatesVisited = world.GetCoordinatesVisitedByTail();
        Assert.Equal(13, uniqueCoordinatesVisited);
    }

    [Fact]
    public void TestTailDoesNotMoveWhenCloseToHead()
    {
        RopeWorld world = new RopeWorld();
        world.HeadPosition = new Coordinate(1, 1);
        world.TailPosition = new Coordinate(1, 1);
        var instructions = new InstructionSet();
        instructions.Commands.Add(new Instruction(Direction.Right, 1));
        world.ExecuteInstructions(instructions);
    
        Assert.Equal(new Coordinate(2, 1), world.HeadPosition);
        Assert.Equal(new Coordinate(1, 1), world.TailPosition);
    }

    [Fact]
    public void TestTailMovesWhenFarFromHead()
    {
        RopeWorld world = new RopeWorld();
        world.HeadPosition = new Coordinate(1, 1);
        world.TailPosition = new Coordinate(1, 1);
        var instructions = new InstructionSet();
        instructions.Commands.Add(new Instruction(Direction.Right, 2));
        world.ExecuteInstructions(instructions);
    
        Assert.Equal(new Coordinate(3, 1), world.HeadPosition);
        Assert.Equal(new Coordinate(2, 1), world.TailPosition);
    }

    [Fact]
    public void TestTailMovesDiagonallyFarFromHead()
    {
        RopeWorld world = new RopeWorld();
        world.HeadPosition = new Coordinate(1, 1);
        world.TailPosition = new Coordinate(1, 1);
        var instructions = new InstructionSet();
        instructions.Commands.Add(new Instruction(Direction.Right, 1));
        instructions.Commands.Add(new Instruction(Direction.Down, 2));
        world.ExecuteInstructions(instructions);
    
        Assert.Equal(new Coordinate(2, -1), world.HeadPosition);
        Assert.Equal(new Coordinate(2, 0), world.TailPosition);
    }
    
    [Fact]
    public void TestCannotDuplicateItemsInHashSet()
    {
        var set = new HashSet<Foo>();
        set.Add(new Foo(1));
        set.Add(new Foo(1));
        set.Add(new Foo(2));
        set.Add(new Foo(2));
        set.Add(new Foo(1));
    
        Assert.Equal(2, set.Count);
    }
    
    record Foo(int number);
}