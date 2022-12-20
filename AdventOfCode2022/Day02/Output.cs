namespace AdventOfCode2022.Day02;

public class Output
{
    public static void Main()
    {
        var gameScore1 = RockPaperScissorsService.CalculateScore(Input.Data, new AssumedMeaningDecoder());
        Console.WriteLine($"Stategy score with assumed meaning: {gameScore1}");
        
        var gameScore2 = RockPaperScissorsService.CalculateScore(Input.Data, new ActualMeaningDecoder());
        Console.WriteLine($"Stategy score with actual meaning: {gameScore2}");
    }
    
}