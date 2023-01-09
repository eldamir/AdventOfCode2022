using AdventOfCode2022.Day06;

namespace Tests.Day06;

public class TestDay06_SignalProcessing
{
    [Fact]
    public void TestStrategyClearsProperly()
    {
        IStrategy strategy = new BreakWhenAllDifferent();
        Scanner scanner = new Scanner(strategy);

        scanner.Scan("aaaa");
        var scanResult = scanner.Scan("bcde");
        
        Assert.NotNull(scanResult);
        Assert.Equal(4, scanResult.Count);
    }
    
    [Fact]
    public void TestCanScanForPattern()
    {
        IStrategy strategy = new BreakWhenAllDifferent();
        Scanner scanner = new Scanner(strategy);

        ScanResult scanResult;
        scanResult = scanner.Scan("bvwbjplbgvbhsrlpgdmjqwftvncz");
        Assert.Equal(5, scanResult.Count);
        scanResult = scanner.Scan("nppdvjthqldpwncqszvftbrmjlhg");
        Assert.Equal(6, scanResult.Count);
        scanResult = scanner.Scan("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg");
        Assert.Equal(10, scanResult.Count);
        scanResult = scanner.Scan("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw");
        Assert.Equal(11, scanResult.Count);
    }
}