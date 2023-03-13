using AdventOfCode2022.Day07;

namespace Tests.Day07;

public class TestDay07_FileSystem
{
    private string _commandString = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";
    
    [Fact]
    public void TestCanParseCommandsAndOutput()
    {
        Scanner scanner = new Scanner();
        List<Command> commands = scanner.Scan(_commandString);
        
        Assert.Equal(10, commands.Count);
        Command command1 = commands[1];
        Assert.Equal("ls", command1.Instruction);
        List<FileSystemItem> items = command1.Output;
        Assert.Equal(FileSystemItemType.Directory, items[0].Type);
        Assert.Equal("a", items[0].Name);
        Assert.Equal(FileSystemItemType.File, items[1].Type);
        Assert.Equal(14848514, items[1].Size);
    }

    [Fact]
    public void TestCanBuildFileTree()
    {
        
        Scanner scanner = new Scanner();
        List<Command> commands = scanner.Scan(_commandString);
        CommandParser parser = new CommandParser();
        FileSystemItem root = parser.Parse(commands);
        
        // /
        Assert.Equal(4, root.Children.Count);
        // /a
        Assert.Equal(4, root.Children[0].Children.Count);
        // /b.txt
        Assert.Empty(root.Children[1].Children);
        // /c.dat
        Assert.Empty(root.Children[2].Children);
        // /d
        Assert.Equal(4, root.Children[3].Children.Count);
    }

    [Fact]
    public void TestCanBuildSumFileSizes()
    {
        Scanner scanner = new Scanner();
        List<Command> commands = scanner.Scan(_commandString);
        CommandParser parser = new CommandParser();
        FileSystemItem root = parser.Parse(commands);

        root.RecalculateFolderSizes();
        
        Assert.Equal(584, root.FindChild("a")!.FindChild("e")!.Size);
        Assert.Equal(94853, root.FindChild("a")!.Size);
        Assert.Equal(24933642, root.FindChild("d")!.Size);
        Assert.Equal(48381165, root.Size);
    }
    
    [Fact]
    public void TestCanQueryFileTree()
    {
        Scanner scanner = new Scanner();
        List<Command> commands = scanner.Scan(_commandString);
        CommandParser parser = new CommandParser();
        FileSystemItem root = parser.Parse(commands);
        root.RecalculateFolderSizes();

        List<FileSystemItem> items = root.Query(
            f => f.Type == FileSystemItemType.Directory && f.Size <= 100000
            );

        var sum = items.Sum(x => x.Size);
        Assert.Equal(95437, sum);
    }
}