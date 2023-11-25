using AdventOfCode2022.Day09.RopeBridge;

namespace AdventOfCode2022.Day09;

public class Output
{
    public static void Main()
    {
        InputScanner inputScanner = new InputScanner();
        InstructionSet instructions = inputScanner.Scan(Input.Data);
        RopeWorld world = new RopeWorld();
        world.SetStepCallback((ropeWorld =>
        {
            Console.WriteLine($"H({ropeWorld.HeadPosition.X}, {ropeWorld.HeadPosition.Y}) T({ropeWorld.TailPosition.X}, {ropeWorld.TailPosition.Y})");
            return ropeWorld;
        }));
        world.ExecuteInstructions(instructions);
    
        int uniqueCoordinatesVisited = world.GetCoordinatesVisitedByTail();
        Console.WriteLine($"Tail visited this many positions: {uniqueCoordinatesVisited}");
        // TODO I keep getting 2694, but that is not the right answer :(
    }
}