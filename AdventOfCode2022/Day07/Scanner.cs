namespace AdventOfCode2022.Day07;

public class Scanner
{
    public List<Command> Scan(string commandString)
    {
        List<Command> results = new();
        Command? currentCommand = null;

        var lines = commandString.Split(Environment.NewLine);

        foreach (var line in lines)
        {
            if (line.StartsWith("$"))
            {
                if (currentCommand != null)
                {
                    results.Add(currentCommand);
                }

                var parts = line.Split(' ');
                currentCommand = new Command(parts[1], parts.Length > 2 ? parts[2] : string.Empty);
            }
            else if (line.StartsWith("dir"))
            {
                currentCommand!.Output.Add(new FileSystemItem
                (
                    line.Split(' ')[1],
                    0,
                    FileSystemItemType.Directory
                ));
            }
            else
            {
                var parts = line.Split(' ');
                currentCommand!.Output.Add(new FileSystemItem
                (
                    parts[1],
                    long.Parse(parts[0]),
                    FileSystemItemType.File
                ));
            }
        }
        
        // Add the last command
        results.Add(currentCommand);

        return results;
    }
}