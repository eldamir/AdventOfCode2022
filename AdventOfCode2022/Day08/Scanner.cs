namespace AdventOfCode2022.Day08;

public class Scanner
{
    public Map Scan(string input)
    {
        var lines = input.Split("\n");
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