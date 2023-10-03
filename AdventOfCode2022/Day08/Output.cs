namespace AdventOfCode2022.Day08;

public class Output {
    public static void Main()
    {
        Part1();
        Part2();
    }

    private static void Part1()
    {
        InputScanner inputScanner = new InputScanner();
        Map map = inputScanner.Scan(Input.Data);
        var scan = new VisibilityScan(map);
        scan.Run();

        var unobstructed = scan.CountValid();
        Console.WriteLine($"Visible trees: {unobstructed}");
    }
    
    private static void Part2()
    {
        InputScanner inputScanner = new InputScanner();
        Map map = inputScanner.Scan(Input.Data);
        var scan = new ScenicScoreScan(map);
        scan.Run();

        var highest = scan.Results.Cast<int>().ToArray().Max();
        Console.WriteLine($"Highest Scenic Score: {highest}");
    }
}