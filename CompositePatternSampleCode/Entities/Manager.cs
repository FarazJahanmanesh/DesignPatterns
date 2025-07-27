namespace CompositePatternSampleCode.Entities;

// مدیر (Composite)

//یک کلاس که فرزندانی از نوع
//Component را نگه می‌دارد
//و عملیات را با استفاده از آن‌ها اجرا می‌کند

public class Manager : IEmployee
{
    public string Name { get; }
    public string Position { get; }
    public double Salary { get; }
    private List<IEmployee> _subordinates = new List<IEmployee>();

    public Manager(string name, string position, double salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void AddSubordinate(IEmployee employee)
    {
        _subordinates.Add(employee);
    }

    public void RemoveSubordinate(IEmployee employee)
    {
        _subordinates.Remove(employee);
    }

    public void DisplayDetails(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 4)}[+] {Name} ({Position}): {Salary:C}");

        foreach (var subordinate in _subordinates)
        {
            subordinate.DisplayDetails(depth + 1);
        }
    }

    public double CalculateTotalSalary()
    {
        double total = Salary;
        foreach (var subordinate in _subordinates)
        {
            total += subordinate.CalculateTotalSalary();
        }
        return total;
    }
}