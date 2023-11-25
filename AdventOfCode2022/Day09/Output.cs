using AdventOfCode2022.Day09.RopeBridge;

namespace AdventOfCode2022.Day09;

public class Output
{
    public static void Main()
    {
        InputScanner inputScanner = new InputScanner();
        InstructionSet instructions = inputScanner.Scan(Input.Data);
        RopeWorld world = new RopeWorld();
        world.ExecuteInstructions(instructions);
    
        int uniqueCoordinatesVisited = world.GetCoordinatesVisitedByTail();
        Console.WriteLine($"Tail visited this many positions: {uniqueCoordinatesVisited}");
    }
}