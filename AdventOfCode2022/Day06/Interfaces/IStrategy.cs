namespace AdventOfCode2022.Day06;

public interface IStrategy
{
    void Clear();
    void Add(char item);
    bool IsInputSatisfied();
    ScanResult Match();
}