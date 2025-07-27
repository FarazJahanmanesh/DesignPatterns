namespace CompositePatternSampleCode.CombineWithSolid.DependencyInversionPrinciple;

public class Employee : IEmployeeBase
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

    public double CalculateTotalSalary() => Salary;
}

public class Manager : IEmployeeBase, IManageSubordinates
{
    private readonly List<IEmployeeBase> _subordinates = new();

    public string Name { get; }
    public string Position { get; }
    public double Salary { get; }

    public Manager(string name, string position, double salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void AddSubordinate(IEmployeeBase employee) => _subordinates.Add(employee);
    public void RemoveSubordinate(IEmployeeBase employee) => _subordinates.Remove(employee);
    public IEnumerable<IEmployeeBase> GetSubordinates() => _subordinates;

    public void DisplayDetails(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 4)}[+] {Name} ({Position}): {Salary:C}");
        foreach (var sub in _subordinates)
            sub.DisplayDetails(depth + 1);
    }

    public double CalculateTotalSalary()
    {
        double total = Salary;
        foreach (var sub in _subordinates)
            total += sub.CalculateTotalSalary();
        return total;
    }
}
