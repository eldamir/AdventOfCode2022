namespace AdventOfCode2022.Day06;

public class Output
{
    public static void Main()
    {
        IStrategy strategy = new BreakWhenAllDifferent();
        Scanner scanner = new Scanner(strategy);
        ScanResult result = scanner.Scan(Input.Data);
        Console.WriteLine($"Characters processed before the first start-of-packet: {result.Count}");
    }
}