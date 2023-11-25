using AdventOfCode2022.Day09.RopeBridge;

namespace AdventOfCode2022.Day09;

public class Output
{
    public static void Main()
    {
        InputScanner inputScanner = new InputScanner();
        InstructionSet instructions = inputScanner.Scan(Input.Data);
        Part1(instructions);
        Part2(instructions);
    }

    private static void Part2(InstructionSet instructions)
    {
        RopeWorld world = new RopeWorld(ropeLength: 10);
        world.ExecuteInstructions(instructions);

        int uniqueCoordinatesVisited = world.GetCoordinatesVisitedByTail();
        Console.WriteLine($"Part2: Tail visited this many positions: {uniqueCoordinatesVisited}");
    }

    private static void Part1(InstructionSet instructions)
    {
        RopeWorld world = new RopeWorld();
        world.ExecuteInstructions(instructions);

        int uniqueCoordinatesVisited = world.GetCoordinatesVisitedByTail();
        Console.WriteLine($"Part1: Tail visited this many positions: {uniqueCoordinatesVisited}");
    }
}