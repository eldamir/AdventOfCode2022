namespace AdventOfCode2022.Day07;

public class CommandParser
{
    public FileSystemItem Parse(List<Command> commands)
    {
        FileSystemItem root = new FileSystemItem("/", 0, FileSystemItemType.Directory);
        FileSystemItem cwd = root;
        
        foreach (var command in commands)
        {
            if (command.Instruction == "cd")
            {
                if (command.Argument == "/")
                {
                    cwd = root;
                }
                else if (command.Argument == "..")
                {
                    if (cwd.Parent != null)
                    {
                        cwd = cwd.Parent;
                    }
                    else
                    {
                        throw new ArgumentException("Attempted '..', but cwd has no parent");
                    }
                }
                else
                {
                    var child = cwd.FindChild(command.Argument);
                    if (child == null)
                    {
                        throw new ArgumentException(
                            $"Attempted 'cd {command.Argument}' but no such child exists");
                    }
                    cwd = child;
                }
            }
            else if (command.Instruction == "ls")
            {
                command.Output.ForEach(item =>
                {
                    cwd.AddChild(item);
                });
            }
            else
            {
                throw new ArgumentException($"Unkown instruction '{command.Instruction}'");
            }
        }

        return root;
    }
}