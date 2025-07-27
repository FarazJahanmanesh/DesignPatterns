namespace CompositePatternSampleCodeSecondRestaurant.Entities;

// آیتم ساده منو
public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public MenuItem(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }
}

// پکیج منو (ترکیبی)
public class MenuPackage
{
    public string Name { get; set; }
    public List<MenuItem> Items { get; set; } = new List<MenuItem>();

    public MenuPackage(string name)
    {
        Name = name;
    }

    public decimal GetPrice()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            total += item.Price;
        }
        return total;
    }
}
