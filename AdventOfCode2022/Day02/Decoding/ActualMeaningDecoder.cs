namespace AdventOfCode2022.Day02;

public class ActualMeaningDecoder : IDecoder
{
    public List<Gesture> DecodeGestures(string symbol1, string symbol2)
    {
        Gesture gesture1 = DecodeGestureSymbol(symbol1);
        GameOutcome desiredOutcome = DecodeOutcomeSymbol(symbol2);
        Gesture gesture2 = FindMatch(gesture1, desiredOutcome);
        return new List<Gesture> { gesture1, gesture2 };
    }

    private Gesture DecodeGestureSymbol(string symbol)
    {
        if (symbol == "A")
        {
            return Gesture.ROCK;
        }
        if (symbol == "B")
        {
            return Gesture.PAPER;
        }
        if (symbol == "C")
        {
            return Gesture.SCISSORS;
        }

        throw new ArgumentException($"{symbol} is an unknown encoding for a gesture");
    }

    private GameOutcome DecodeOutcomeSymbol(string symbol)
    {
        if (symbol == "X")
        {
            return GameOutcome.LOSE;
        }
        if (symbol == "Y")
        {
            return GameOutcome.DRAW;
        }
        if (symbol == "Z")
        {
            return GameOutcome.WIN;
        }

        throw new ArgumentException($"{symbol} is an unknown encoding for a gesture");
    }

    private Gesture FindMatch(Gesture gesture, GameOutcome desiredOutcome)
    {
        if (desiredOutcome == GameOutcome.DRAW)
        {
            return gesture;  // Match their gesture
        }
        if (gesture == Gesture.ROCK)
        {
            if (desiredOutcome == GameOutcome.WIN)
            {
                return Gesture.PAPER;
            }
            return Gesture.SCISSORS;
        }
        if (gesture == Gesture.PAPER)
        {
            if (desiredOutcome == GameOutcome.WIN)
            {
                return Gesture.SCISSORS;
            }
            return Gesture.ROCK;
        }
        else
        {
            if (desiredOutcome == GameOutcome.WIN)
            {
                return Gesture.ROCK;
            }
            return Gesture.PAPER;
        }
    }
}