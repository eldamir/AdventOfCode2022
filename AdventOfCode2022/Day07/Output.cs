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

        List<FileSystemItem> itemsPart1 = root.Query(
            f => f.Type == FileSystemItemType.Directory && f.Size <= 100000
            );

        var sum = itemsPart1.Sum(x => x.Size);
        Console.WriteLine($"Sum of folder sizes where size is at most 100000: {sum}");

        long diskSize = 70000000;
        long neededSpace = 30000000;
        long usedSpace = root.Size;
        long unusedSpace = diskSize - usedSpace;
        List<FileSystemItem> itemsPart2 = root.Query(
            f => f.Type == FileSystemItemType.Directory 
                 && f.Size + unusedSpace >= neededSpace
            );

        var item = itemsPart2.OrderBy(x => x.Size).First();
        Console.WriteLine($"Smallest folder to delete, that makes enough room is: " +
                          $"{item.Name} with {item.Size}");
    }
}