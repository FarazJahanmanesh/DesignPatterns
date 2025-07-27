namespace CompositePatternSampleCode.CombineWithSolid.SingleResponsibilityPrinciple;

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

    public double CalculateTotalSalary()
    {
        return Salary;
    }

    public IReadOnlyList<IEmployee> GetSubordinates()
    {
        // Leaf زیرمجموعه نداره
        return Array.Empty<IEmployee>();
    }
}