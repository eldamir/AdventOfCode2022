namespace AdventOfCode2022.Day02;

public interface IDecoder
{
    public List<Gesture> DecodeGestures(string symbol1, string symbol2);
}