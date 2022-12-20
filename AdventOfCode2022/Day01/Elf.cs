namespace AdventOfCode2022.Day01;

public class Elf
{
    private List<int> _calories;
    public int TotalCalories => _calories.Sum();

    public Elf(IEnumerable<int> calories)
    {
        _calories = calories.ToList();
    }

    public static Elf FromCaloriesString(string calories)
    {
        List<int> caloryList;
        try
        {
            caloryList = calories
                .Split(Environment.NewLine)
                .Select(n => int.Parse(n))
                .ToList();
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't parse {calories}", ex);
        }

        return new Elf(caloryList);
    }
}