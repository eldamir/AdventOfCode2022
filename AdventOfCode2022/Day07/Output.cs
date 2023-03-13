namespace AdventOfCode2022.Day07;

public class Output
{
    public static void Main()
    {
        Scanner scanner = new Scanner();
        List<Command> commands = scanner.Scan(Input.Data);
        CommandParser parser = new CommandParser();
        FileSystemItem root = parser.Parse(commands);
        root.RecalculateFolderSizes();

        List<FileSystemItem> items = root.Query(
            f => f.Type == FileSystemItemType.Directory && f.Size <= 100000
            );

        var sum = items.Sum(x => x.Size);
        Console.WriteLine($"Sum of folder sizes where size is at most 100000: {sum}");
    }
}