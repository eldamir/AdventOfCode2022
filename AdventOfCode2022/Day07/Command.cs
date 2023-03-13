namespace AdventOfCode2022.Day07;

public class Command
{
    public string Instruction { get; set; }
    public string Argument { get; set; }
    public List<FileSystemItem> Output;
    
    public Command(string instruction, string argument)
    {
        Instruction = instruction;
        Argument = argument;
        Output = new();
    }

}