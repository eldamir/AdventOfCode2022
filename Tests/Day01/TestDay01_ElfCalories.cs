using AdventOfCode2022.Day01;

namespace Tests;

public class UnitTest1
{
    public static string Data = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

    [Fact]
    public void TestCanGetHighestCalories()
    {
        var elfList = ElfService.CreateElvesFromString(Data);
        var highesetElfCalories = ElfService.GetHighestCalories(elfList);
        
        Assert.Equal(24000, highesetElfCalories);
    }

    [Fact]
    public void TestCanGetTop3Sum()
    {
        var elfList = ElfService.CreateElvesFromString(Data);
        var highesetElfCalories = ElfService.GetTop3Sum(elfList);
        
        Assert.Equal(45000, highesetElfCalories);
    }
}