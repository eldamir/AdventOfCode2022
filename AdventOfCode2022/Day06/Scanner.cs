namespace AdventOfCode2022.Day06;

public class Scanner
{
    private IStrategy _strategy;
    
    public Scanner(IStrategy strategy)
    {
        _strategy = strategy;
    }

    public ScanResult Scan(string stringToScan)
    {
        ScanResult result = null;
        StringReader reader = new StringReader(stringToScan);
        
        _strategy.Clear();

        while (!_strategy.IsInputSatisfied() && reader.Peek() != -1)
        {
            _strategy.Add((char)reader.Read());
        }

        do
        {
            result = _strategy.Match();
            if (result != null)
            {
                return result;
            }
            _strategy.Add((char)reader.Read());
        } while (reader.Peek() != -1);

        return result;
    }
}