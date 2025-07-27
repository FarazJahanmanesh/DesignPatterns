using CompositePatternSampleCodeRestaurant.CompositePattern;
using CompositePatternSampleCodeRestaurant.Entities;

namespace CompositePatternSampleCodeRestaurant;

public class Program
{
    static void Main(string[] args)
    {
        List<MenuItem> items = new List<MenuItem>
        {
            new MenuItem
            {
                Id = 1,
                Name = "coca cola",
                Price = 10000
            },
            new MenuItem
            {
                Id = 2,
                Name = "sibzamini",
                Price = 100000
            },
            new MenuItem
            {
                Id = 3,
                Name = "burger",
                Price = 150000
            },
            new MenuItem
            {
                Id = 4,
                Name = "sabad coca cola (3 koka)",
                Price = 30000
            },
            new MenuItem
            {
                Id = 5,
                Name = "pack khanvadgi (sibzamini and sabad coca cola and burger)",
                Price = 280000
            },

        };

        Menu menu = new Menu()
        {
            RestaurantName = "Fara Ofogh",
            MenuItems = items
        };

        Console.WriteLine("Menu");
        Console.WriteLine(menu.RestaurantName);
        foreach (MenuItem item in menu.MenuItems)
            Console.WriteLine($"{item.Name} , Price : {item.Price}");

        Console.WriteLine("---------------------i want to change coca cola price from 10000 to 20000---------------------");

        items[0].Price = 20000;
        items[3].Price = 60000;
        items[4].Price = 310000;
        Console.WriteLine("Menu");
        Console.WriteLine(menu.RestaurantName);
        foreach (MenuItem item in menu.MenuItems)
            Console.WriteLine($"{item.Name} , Price : {item.Price}");





        Console.WriteLine("-----------------------------------------CompositePattern-----------------------------------------");
        ///////////////////////////// CompositePattern

        var coca = new MenuItemLeaf("Coca Cola", 10000);
        var sibzamini = new MenuItemLeaf("sibzamini", 100000);
        var burger = new MenuItemLeaf("burger", 150000);

        var cocaPack = new MenuComposite("Coke Pack (3 Coca Cola)");
        cocaPack.Add(coca);
        cocaPack.Add(coca);
        cocaPack.Add(coca);

        var familyPack = new MenuComposite("Family Pack");
        familyPack.Add(sibzamini);
        familyPack.Add(cocaPack);
        familyPack.Add(burger);

        var menuFaraOfogh = new MenuComposite("Fara Ofogh Menu");
        menuFaraOfogh.Add(coca);
        menuFaraOfogh.Add(sibzamini);
        menuFaraOfogh.Add(burger);
        menuFaraOfogh.Add(cocaPack);
        menuFaraOfogh.Add(familyPack);

        Console.WriteLine("----- Menu Before Price Change -----");
        menuFaraOfogh.Display();

        coca.Price = 20000;

        Console.WriteLine("\n----- Menu After Price Change -----");
        menuFaraOfogh.Display();

        Console.WriteLine($"\nFamily Pack New Price: {familyPack.GetPrice()}");
    }
}
