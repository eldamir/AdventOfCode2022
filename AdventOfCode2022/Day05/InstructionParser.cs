using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;

namespace AdventOfCode2022.Day05;

public class InstructionParser
{
    public static List<MoveInstruction> Parse(string data)
    {
        // Get the instruction part of the data and discard the stack data
        var instructionString = data.Split(Environment.NewLine + Environment.NewLine)[1];

        return instructionString
            .Split(Environment.NewLine)
            .Select(line => Regex.Matches(line, @"\d+").Select(match => int.Parse(match.Value)).ToList())
            .Select(parts => new MoveInstruction
            {
                Count = parts[0],
                From = parts[1],
                To = parts[2],
            }).ToList();
    }
}