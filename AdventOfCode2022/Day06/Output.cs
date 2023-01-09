namespace AdventOfCode2022.Day06;

public class Output
{
    public static void Main()
    {
        IStrategy strategy;
        Scanner scanner;
        ScanResult result;
        
        strategy = new StartOfPacket();
        scanner = new Scanner(strategy);
        result = scanner.Scan(Input.Data);
        Console.WriteLine($"Characters processed before the first start-of-packet: {result.Count}");
        
        strategy = new StartOfMessage();
        scanner = new Scanner(strategy);
        result = scanner.Scan(Input.Data);
        Console.WriteLine($"Characters processed before the first start-of-message: {result.Count}");
    }
}