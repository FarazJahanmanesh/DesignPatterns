namespace CompositePatternSampleCode.CombineWithSolid.LiskovSubstitutionPrinciple;

public class Manager : IEmployee
{
    public string Name { get; }
    public string Position { get; }
    public double Salary { get; }

    private readonly List<IEmployee> _subordinates = new();

    public Manager(string name, string position, double salary)
    {
        Name = name;
        Position = position;
        Salary = salary;
    }

    public void AddSubordinate(IEmployee employee) => _subordinates.Add(employee);

    public void RemoveSubordinate(IEmployee employee) => _subordinates.Remove(employee);

    public double CalculateTotalSalary()
    {
        double total = Salary;
        foreach (var sub in _subordinates)
            total += sub.CalculateTotalSalary();
        return total;
    }

    public IReadOnlyList<IEmployee> GetSubordinates() => _subordinates.AsReadOnly();
}
