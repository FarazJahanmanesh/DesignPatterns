using Ens = CompositePatternSampleCodeSecondRestaurant.Entities;
using Com = CompositePatternSampleCodeSecondRestaurant.Composite;

namespace CompositePatternSampleCodeSecondRestaurant;

public class Program
{
    static void Main(string[] args)
    {
        //اگر بخواهی یک پکیج داخل پکیج دیگر داشته باشی،
        //باید دوباره کلاس جدیدی بسازی یا متد های جدید اضافه کنی،
        //چون پکیج‌ها فقط می‌ توانند شامل
        //MenuItem باشند نه خود پکیج‌ ها.
        //نیاز است وقتی قیمت آیتم تغییر کرد، به صورت دستی قیمت پکیج‌ ها را به‌ روزرسانی کنی.
        //کد مدیریت سلسله‌ مراتب و رفتار یکسان آیتم‌ها و پکیج‌ها پراکنده و تکراری می‌شود.

        // ایجاد آیتم‌های ساده
        var pizza = new Ens.MenuItem(1, "Pizza", 20m);
        var salad = new Ens.MenuItem(2, "Salad", 10m);
        var soda = new Ens.MenuItem(3, "Soda", 5m);

        // ایجاد پکیج
        var familyPackage = new Ens.MenuPackage("Family Package");
        familyPackage.Items.Add(pizza);
        familyPackage.Items.Add(salad);
        familyPackage.Items.Add(soda);

        // نمایش منو
        Console.WriteLine($"{pizza.Name}: {pizza.Price:C}");
        Console.WriteLine($"{salad.Name}: {salad.Price:C}");
        Console.WriteLine($"{soda.Name}: {soda.Price:C}");

        Console.WriteLine($"{familyPackage.Name}: {familyPackage.GetPrice():C}");



        Console.WriteLine("-----------------------------------------CompositePattern-----------------------------------------");
        ///////////////////////////// CompositePattern

        var pizza1 = new Com.MenuItem("Pizza", 20m);
        var salad1 = new Com.MenuItem("Salad", 10m);
        var soda1 = new Com.MenuItem("Soda", 5m);

        var familyPackage1 = new Com.MenuPackage("Family Package");
        familyPackage1.Add(pizza1);
        familyPackage1.Add(salad1);
        familyPackage1.Add(soda1);

        familyPackage1.Display();
        Console.WriteLine($"Total Price: {familyPackage1.GetPrice():C}");
    }
}
