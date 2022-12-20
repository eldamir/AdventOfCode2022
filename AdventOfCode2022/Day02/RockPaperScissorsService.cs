namespace AdventOfCode2022.Day02;

public class RockPaperScissorsService
{
    public static int CalculateScore(string data, IDecoder decoder)
    {
        var rounds = data
            .Split(Environment.NewLine)
            .Select(roundString => roundString.Split(' ').ToList())
            .Select(gestureStrings => decoder.DecodeGestures(gestureStrings[0], gestureStrings[1]))
            .Select(gestures => new GameRound(gestures[0], gestures[1]));

        var roundPoints = rounds.Sum(r => r.GetScore());
        return roundPoints;
    }
}