namespace CompositePatternSampleCode.CombineWithSolid.InterfaceSegregationPrinciple;

public interface IEmployeeBase
{
    string Name { get; }
    string Position { get; }
    double Salary { get; }

    void DisplayDetails(int depth = 0);
    double CalculateTotalSalary();
}
