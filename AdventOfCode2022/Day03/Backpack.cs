namespace AdventOfCode2022.Day03;

public class Backpack
{
    public List<SupplyItem> Compartment1 { get; }
    public List<SupplyItem> Compartment2 { get; }

    public Backpack()
    {
        Compartment1 = new List<SupplyItem>();
        Compartment2 = new List<SupplyItem>();
    }
    
    public Backpack(List<SupplyItem> items)
    {
        Compartment1 = new List<SupplyItem>();
        Compartment2 = new List<SupplyItem>();
        RePack(items);
    }

    public void RePack(List<SupplyItem> items)
    {
        var half = items.Count / 2;
        var firstHalf = items.Take(half);
        var secondHalf = items.Skip(half);
        
        Compartment1.Clear();
        Compartment1.AddRange(firstHalf);
        Compartment2.Clear();
        Compartment2.AddRange(secondHalf);
    }
}