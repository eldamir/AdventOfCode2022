using System;

namespace AdventOfCode2022.Day01;

public class Output
{
    public static void Main()
    {
        var elfList = ElfService.CreateElvesFromString(Input.Data);
        var highesetElfCalories = ElfService.GetHighestCalories(elfList);
        var top3Calories = ElfService.GetTop3Sum(elfList);
        Console.WriteLine($"Highest Elf Calories: {highesetElfCalories}");
        Console.WriteLine($"Top 3 Calories: {top3Calories}");
    }
}