namespace CompositePatternSampleCodeSecondRestaurant.Composite;

// Component
public interface IMenuComponent
{
    string Name { get; }
    decimal GetPrice();
    void Display(int depth = 0);
}

// Leaf
public class MenuItem : IMenuComponent
{
    public string Name { get; }
    private decimal Price { get; }

    public MenuItem(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public decimal GetPrice() => Price;

    public void Display(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}- {Name}: {Price:C}");
    }
}

// Composite
public class MenuPackage : IMenuComponent
{
    public string Name { get; }
    private List<IMenuComponent> _items = new();

    public MenuPackage(string name)
    {
        Name = name;
    }

    public void Add(IMenuComponent item)
    {
        _items.Add(item);
    }

    public decimal GetPrice()
    {
        decimal total = 0;
        foreach (var item in _items)
            total += item.GetPrice();
        return total;
    }

    public void Display(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 2)}[Package] {Name}: {GetPrice():C}");
        foreach (var item in _items)
            item.Display(depth + 1);
    }
}
