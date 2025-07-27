namespace CompositePatternSampleCode.CombineWithSolid.SingleResponsibilityPrinciple;

public class Manager : IEmployee
{
    public string Name { get; }
    public string Position { get; }
    public double Salary { get; }

    private readonly List<IEmployee> _subordinates = new List<IEmployee>();

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

    public double CalculateTotalSalary()
    {
        double total = Salary;
        foreach (var emp in _subordinates)
            total += emp.CalculateTotalSalary();
        return total;
    }

    public IReadOnlyList<IEmployee> GetSubordinates()
    {
        return _subordinates.AsReadOnly();
    }
}
