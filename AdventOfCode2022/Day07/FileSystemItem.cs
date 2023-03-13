namespace AdventOfCode2022.Day07;

public class FileSystemItem
{
    public FileSystemItem(string name, long size, FileSystemItemType type, FileSystemItem parent = null)
    {
        Name = name;
        Size = size;
        Type = type;
        _children = new();
        Parent = parent;
    }

    public string Name { get; set; }
    public long Size { get; set; }
    public FileSystemItemType Type { get; set; }
    public FileSystemItem? Parent { get; set; }
    
    private List<FileSystemItem> _children = new List<FileSystemItem>();
    public IReadOnlyList<FileSystemItem> Children => _children.AsReadOnly();

    public FileSystemItem? FindChild(string name)
    {
        return _children.FirstOrDefault(child => child.Name == name);
    }

    public void AddChild(FileSystemItem child)
    {
        if (FindChild(child.Name) == null)
        {
            _children.Add(child);
            child.Parent = this;
        }
        else
        {
            throw new ArgumentException(
                $"{child.Name}' is already a child!");
        }
    }

    public void RecalculateFolderSizes()
    {
        long sum = 0;
        _children.ForEach(child =>
        {
            if (child.Type == FileSystemItemType.File)
            {
                sum += child.Size;
            }
            else
            {
                child.RecalculateFolderSizes();
                sum += child.Size;
            }
        });
        Size = sum;
    }

    public List<FileSystemItem> Query(Func<FileSystemItem, bool> predicate)
    {
        List<FileSystemItem> results = new List<FileSystemItem>();
        if (predicate(this))
        {
            results.Add(this);
        }
        _children.ForEach(child =>
        {
            results.AddRange(child.Query(predicate));
        });
        return results;
    }
}