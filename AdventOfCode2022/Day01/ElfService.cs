namespace AdventOfCode2022.Day01;

public class ElfService
{
    public static List<Elf> CreateElvesFromString(string data)
    {
        var elfStrings = data.Split(Environment.NewLine + Environment.NewLine);
        return elfStrings.ToList().Select(s => Elf.FromCaloriesString(s)).ToList();
    }

    public static int GetHighestCalories(List<Elf> elves)
    {
        return elves.OrderByDescending(e => e.TotalCalories).Take(1).First().TotalCalories;
    }

    public static int GetTop3Sum(List<Elf> elves)
    {
        return elves.OrderByDescending(e => e.TotalCalories).Take(3).Sum(e => e.TotalCalories);
    }
}