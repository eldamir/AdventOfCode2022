namespace AdventOfCode2022.Day05;

public class StackParser
{
    public static StackCollection Parse(string data)
    {
        // Get the stack part of the data and discard the instructions
        var stackString = data.Split(Environment.NewLine + Environment.NewLine)[0];
        var lines = stackString.Split(Environment.NewLine);
        var stackCount = lines.Last().Replace(" ", "").Length; // Number of lines without the header line

        var stackCollection = new StackCollection(stackCount);

        var stackLines = lines.Reverse().Skip(1).ToList();

        var stackTarget = 1;
        stackLines.ForEach(line => line.ToList().Chunk(4).ToList().ForEach((chunk) =>
            {
                var identifier = chunk[1];

                if (identifier != ' ')
                {
                    stackCollection.PushToStack(stackTarget, new ShippingContainer(chunk[1]));
                }

                stackTarget = (stackTarget % stackCount)  + 1;
            }
        ));

        return stackCollection;
    }
}