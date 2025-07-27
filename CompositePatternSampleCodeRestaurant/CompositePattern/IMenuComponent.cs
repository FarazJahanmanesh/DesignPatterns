namespace CompositePatternSampleCodeRestaurant.CompositePattern;

public interface IMenuComponent
{
    string Name { get; }
    int GetPrice();          
    void Display(int depth = 0);
}

public class MenuItemLeaf : IMenuComponent
{
    public string Name { get; }
    private int _price;
    public int Price
    {
        get => _price;
        set => _price = value;
    }

    public MenuItemLeaf(string name, int price)
    {
        Name = name;
        _price = price;
    }

    public int GetPrice() => _price;

    public void Display(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 4)}- {Name}: {GetPrice()}");
    }
}

public class MenuComposite : IMenuComponent
{
    public string Name { get; }
    private List<IMenuComponent> _children = new();

    public MenuComposite(string name)
    {
        Name = name;
    }

    public void Add(IMenuComponent component)
    {
        _children.Add(component);
    }

    public void Remove(IMenuComponent component)
    {
        _children.Remove(component);
    }

    public int GetPrice()
    {
        int total = 0;
        foreach (var child in _children)
        {
            total += child.GetPrice();
        }
        return total;
    }

    public void Display(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 4)}[+] {Name}: {GetPrice()}");
        foreach (var child in _children)
        {
            child.Display(depth + 1);
        }
    }
}