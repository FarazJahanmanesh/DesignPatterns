namespace CompositePatternSampleCode.CombineWithSolid.InterfaceSegregationPrinciple;

public class Manager : IEmployeeBase, IManageSubordinates
{
    private List<IEmployeeBase> _subordinates = new List<IEmployeeBase>();

    public string Name { get; }
    public string Position { get; }
    public double Salary { get; }

    public Manager(string name, string position, double salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void AddSubordinate(IEmployeeBase employee)
    {
        _subordinates.Add(employee);
    }

    public void RemoveSubordinate(IEmployeeBase employee)
    {
        _subordinates.Remove(employee);
    }

    public IEnumerable<IEmployeeBase> GetSubordinates()
    {
        return _subordinates;
    }

    public void DisplayDetails(int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 4)}[+] {Name} ({Position}): {Salary:C}");
        foreach (var sub in _subordinates)
        {
            sub.DisplayDetails(depth + 1);
        }
    }

    public double CalculateTotalSalary()
    {
        double total = Salary;
        foreach (var sub in _subordinates)
        {
            total += sub.CalculateTotalSalary();
        }
        return total;
    }
}
