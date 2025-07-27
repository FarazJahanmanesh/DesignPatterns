namespace CompositePatternSampleCodeRestaurant.Entities;

public class Menu
{
    public string RestaurantName { get;set; }
    public List<MenuItem> MenuItems { get; set;}
}
public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}
