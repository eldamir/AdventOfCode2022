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
    public void TestCanParseInputWithNumbersLargerThan9()
    {
        InputScanner inputScanner = new InputScanner();
        InstructionSet instructions = inputScanner.Scan("R 9\nD 9001");
        
        Assert.Equal(2, instructions.Commands.Count);
        Assert.Equal(Direction.Right, instructions.Commands[0].Direction);
        Assert.Equal(9, instructions.Commands[0].Steps);
        Assert.Equal(Direction.Down, instructions.Commands[1].Direction);
        Assert.Equal(9001, instructions.Commands[1].Steps);
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
    public void TestCanMoveRight()
    {
        InstructionSet instructions = new InstructionSet();
        instructions.Commands.Add(new Instruction(Direction.Right, 3));
        
        RopeWorld world = new RopeWorld();
        world.ExecuteInstructions(instructions);
        
        Assert.Equal(new Coordinate(3, 0), world.HeadPosition); 
    }

    [Fact]
    public void TestCanMoveLeft()
    {
        InstructionSet instructions = new InstructionSet();
        instructions.Commands.Add(new Instruction(Direction.Left, 3));
        
        RopeWorld world = new RopeWorld();
        world.ExecuteInstructions(instructions);
        
        Assert.Equal(new Coordinate(-3, 0), world.HeadPosition); 
    }

    [Fact]
    public void TestCanMoveUp()
    {
        InstructionSet instructions = new InstructionSet();
        instructions.Commands.Add(new Instruction(Direction.Up, 3));
        
        RopeWorld world = new RopeWorld();
        world.ExecuteInstructions(instructions);
        
        Assert.Equal(new Coordinate(0, 3), world.HeadPosition); 
    }

    [Fact]
    public void TestCanMoveDown()
    {
        InstructionSet instructions = new InstructionSet();
        instructions.Commands.Add(new Instruction(Direction.Down, 3));
        
        RopeWorld world = new RopeWorld();
        world.ExecuteInstructions(instructions);
        
        Assert.Equal(new Coordinate(0, -3), world.HeadPosition); 
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
    

    [Fact]
    public void TestCanMoveLongerRopeInSameManner()
    {
        var instructionString = @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20";
        RopeWorld world = new RopeWorld(ropeLength:10);
        InputScanner inputScanner = new InputScanner();
        InstructionSet instructions = inputScanner.Scan(instructionString);
        world.ExecuteInstructions(instructions);
    
        Assert.Equal(36, world.GetCoordinatesVisitedByTail());
    }
}