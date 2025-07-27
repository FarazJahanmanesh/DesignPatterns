namespace CompositePatternSampleCode.Entities;

// کارمند ساده (Leaf)

//یک کلاس که فرزند ندارد
//و عملیات را فقط برای خودش انجام می‌دهد

public class Employee : IEmployee
{
    public string Name { get; }
    public string Position { get; }
    public double Salary { get; }

    public Employee(string name, string position, double salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void DisplayDetails(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 4)}- {Name} ({Position}): {Salary:C}");
    }

    public double CalculateTotalSalary()
    {
        return Salary;
    }
}