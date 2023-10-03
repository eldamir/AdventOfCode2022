namespace AdventOfCode2022.Day08;

public class Output {
    public static void Main()
    {
        Scanner scanner = new Scanner();
        Map map = scanner.Scan(Input.Data);
        map.InvalidateObstructed();

        var unobstructed = map.CountValid();
        Console.WriteLine($"Visible trees: {unobstructed}");
    }
}