namespace AdventOfCode2022.Day09.RopeBridge;

public class RopeWorld
{
    public Coordinate HeadPosition = new(0, 0);
    public Coordinate TailPosition = new(0, 0);
    private readonly List<Coordinate> _rope = new();
    private readonly HashSet<Coordinate> _positionsVisitedByTail = new();

    public RopeWorld(int ropeLength = 2)
    {
        _positionsVisitedByTail.Add(new Coordinate(0, 0));
        for (int i = 0; i < ropeLength; i++)
        {
            _rope.Add(new Coordinate(0, 0));
        }
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

        _rope[0] = HeadPosition;
    }

    private void MoveTail()
    {
        for (int i = 1; i < _rope.Count; i++)
        {
            
            MoveTailPart(_rope[i], _rope[i - 1], i);
        }

        var tail = _rope.Last();
        var tailIndex = _rope.Count - 1;
        MoveTailPart(tail, _rope[tailIndex - 1], tailIndex);
        TailPosition = tail;
        _positionsVisitedByTail.Add(TailPosition);
    }

    private void MoveTailPart(Coordinate tailPart, Coordinate parentLink, int tailIndex)
    {
        int deltaX = parentLink.X - tailPart.X;
        int deltaY = parentLink.Y - tailPart.Y;
        
        // If the head is in a neighboring spot, the tail does not move
        var isNeighbor = Math.Abs(deltaX) <= 1 && Math.Abs(deltaY) <= 1;
        if (!isNeighbor)
        {
            int movementHorizontal = deltaX == 0 ? 0 : deltaX / Math.Abs(deltaX);
            int movementVertical = deltaY == 0 ? 0 : deltaY / Math.Abs(deltaY);

            _rope[tailIndex] = tailPart with
            {
                X = tailPart.X + movementHorizontal,
                Y = tailPart.Y + movementVertical
            };
        }
    }

    public int GetCoordinatesVisitedByTail()
    {
        return _positionsVisitedByTail.Count;
    }
}