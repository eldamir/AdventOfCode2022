using AdventOfCode2022.Day08;

namespace Tests.Day08;

public class TestDay08_TreeHouse
{
    private readonly string _commandString = @"30373
25512
65332
33549
35390";
    
    [Fact]
    public void TestCanParseInput()
    {
        InputScanner inputScanner = new InputScanner();
        Map map = inputScanner.Scan(_commandString);
        
        Assert.Equal(3, map.GetValue(0, 0));
        Assert.Equal(0, map.GetValue(1, 0));
        Assert.Equal(3, map.GetValue(2, 0));
        Assert.Equal(7, map.GetValue(3, 0));
        Assert.Equal(3, map.GetValue(4, 0));
        Assert.Equal(5, map.GetValue(1, 1));
        Assert.Equal(3, map.GetValue(2, 2));
        Assert.Equal(4, map.GetValue(3, 3));
    }
    
    [Fact]
    public void TestCanCount()
    {
        InputScanner inputScanner = new InputScanner();
        Map map = inputScanner.Scan(_commandString);
        var scan = new VisibilityScan(map);
        
        Assert.Equal(25, scan.CountValid());
    }
    
    [Fact]
    public void TestCanFindVisibleTrees()
    {
        InputScanner inputScanner = new InputScanner();
        Map map = inputScanner.Scan(_commandString);
        var scan = new VisibilityScan(map);
        scan.Run();

        var unobstructed = scan.CountValid();
        
        Assert.Equal(21, unobstructed);
    }
    
    [Fact]
    public void TestCanFindScenicScores()
    {
        InputScanner inputScanner = new InputScanner();
        Map map = inputScanner.Scan(_commandString);
        var scan = new ScenicScoreScan(map);
        scan.Run();

        Assert.Equal(4, scan.Get(2, 1));
        Assert.Equal(8, scan.Get(2, 3));
    }
}