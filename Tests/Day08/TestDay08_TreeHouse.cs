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
        Scanner scanner = new Scanner();
        Map map = scanner.Scan(_commandString);
        
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
        Scanner scanner = new Scanner();
        Map map = scanner.Scan(_commandString);
        
        Assert.Equal(25, map.CountValid());
    }
    
    [Fact]
    public void TestCanFindVisibleTrees()
    {
        Scanner scanner = new Scanner();
        Map map = scanner.Scan(_commandString);
        map.InvalidateObstructed();

        var unobstructed = map.CountValid();
        
        Assert.Equal(21, unobstructed);
    }
}