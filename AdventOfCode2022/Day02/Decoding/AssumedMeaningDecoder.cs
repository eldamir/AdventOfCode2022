namespace AdventOfCode2022.Day02;

public class AssumedMeaningDecoder : IDecoder
{
    public List<Gesture> DecodeGestures(string symbol1, string symbol2)
    {
        return new List<Gesture>
        {
            DecodeSymbol(symbol1),
            DecodeSymbol(symbol2)
        };
    }

    private Gesture DecodeSymbol(string symbol)
    {
        var rocks = new[] { "A", "X" };
        var papers = new[] { "B", "Y" };
        var scissors = new[] { "C", "Z" };

        if (rocks.Contains(symbol))
        {
            return Gesture.ROCK;
        }
        if (papers.Contains(symbol))
        {
            return Gesture.PAPER;
        }
        if (scissors.Contains(symbol))
        {
            return Gesture.SCISSORS;
        }

        throw new ArgumentException($"{symbol} is an unknown encoding for a gesture");
    }
}