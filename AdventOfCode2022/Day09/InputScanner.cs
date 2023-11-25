using AdventOfCode2022.Day09.RopeBridge;

namespace AdventOfCode2022.Day09;

public class InputScanner
{
    public InstructionSet Scan(string input)
    {
        var lines = input.Split("\n").Select(x => x.Trim()).ToArray();

        var instructions = new InstructionSet();

        foreach (var line in lines)
        {
            var directionChar = line[0];
            var stepsString = line.Substring(2);

            var direction = directionChar switch
            {
                'L' => Direction.Left,
                'R' => Direction.Right,
                'U' => Direction.Up,
                'D' => Direction.Down,
                _ => Direction.Unknown
            };
            var steps = int.Parse(stepsString);
            var command = new Instruction(direction, steps);
            instructions.Commands.Add(command);
        }

        return instructions;
    }
}