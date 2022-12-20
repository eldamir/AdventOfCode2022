namespace AdventOfCode2022.Day05;

public class ShippingContainer
{
    public char Identifier { get; private set; }

    public ShippingContainer(char identifier)
    {
        Identifier = identifier;
    }
}