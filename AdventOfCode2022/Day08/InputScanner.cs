namespace AdventOfCode2022.Day08;

public class InputScanner
{
    public Map Scan(string input)
    {
        var lines = input.Split("\n").Select(x => x.Trim()).ToArray();
        var height = lines.Length;
        var width = lines.First().Length;

        var map = new Map(width, height);

        int x = 0;
        int y = 0;
        foreach (var line in lines)
        {
            foreach (var character in line.ToCharArray())
            {
                int number = int.Parse(character.ToString());
                map.SetValue(x, y, number);
                x++;
            }

            x = 0;
            y++;
        }

        return map;
    }
}