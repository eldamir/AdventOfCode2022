namespace AdventOfCode2022.Day09.RopeBridge;

public class RopeWorld
{
    public Coordinate HeadPosition = new(0, 0);
    public Coordinate TailPosition = new(0, 0);
    private readonly HashSet<Coordinate> _positionsVisitedByTail = new();

    public RopeWorld()
    {
        _positionsVisitedByTail.Add(new Coordinate(0, 0));
    }

    public void ExecuteInstructions(InstructionSet instructions)
    {
        foreach (var instruction in instructions.Commands)
        {
            for (int i = 0; i < instruction.Steps; i++)
            {
                MoveHead(instruction);
                MoveTail();
            }
        }
    }

    private void MoveHead(Instruction instruction)
    {
        switch (instruction.Direction)
        {
            case Direction.Right:
                HeadPosition = HeadPosition with { X = HeadPosition.X + 1 };
                break;
            case Direction.Left:
                HeadPosition = HeadPosition with { X = HeadPosition.X - 1 };
                break;
            case Direction.Up:
                HeadPosition = HeadPosition with { Y = HeadPosition.Y + 1 };
                break;
            case Direction.Down:
                HeadPosition = HeadPosition with { Y = HeadPosition.Y - 1 };
                break;
        }
    }

    private void MoveTail()
    {
        int deltaX = HeadPosition.X - TailPosition.X;
        int deltaY = HeadPosition.Y - TailPosition.Y;
        
        // If the head is in a neighboring spot, the tail does not move
        var isNeighbor = Math.Abs(deltaX) <= 1 && Math.Abs(deltaY) <= 1;
        if (!isNeighbor)
        {
            int movementHorizontal = deltaX == 0 ? 0 : deltaX / Math.Abs(deltaX);
            int movementVertical = deltaY == 0 ? 0 : deltaY / Math.Abs(deltaY);

            TailPosition = TailPosition with
            {
                X = TailPosition.X + movementHorizontal,
                Y = TailPosition.Y + movementVertical
            };
        }
        _positionsVisitedByTail.Add(TailPosition);
    }

    public int GetCoordinatesVisitedByTail()
    {
        return _positionsVisitedByTail.Count;
    }
}