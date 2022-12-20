using AdventOfCode2022.Day02;

namespace Tests.Day02;

public class TestDay02_RockPapaerScissors
{
    public static string Data = @"A Y
B X
C Z";
    
    [Fact]
    public void TestCanCalculateScoreWithAssumedMeaning()
    {
        var score = RockPaperScissorsService.CalculateScore(Data, new AssumedMeaningDecoder());
        Assert.Equal(15, score);
    }
    
    [Fact]
    public void TestCanCalculateScoreWithActualMeaning()
    {
        var score = RockPaperScissorsService.CalculateScore(Data, new ActualMeaningDecoder());
        Assert.Equal(12, score);
    }
}