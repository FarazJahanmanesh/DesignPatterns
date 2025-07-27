namespace CompositePatternSampleCode.CombineWithSolid.LiskovSubstitutionPrinciple;

public interface IEmployee
{
    string Name { get; }
    string Position { get; }
    double Salary { get; }
    double CalculateTotalSalary();
    IReadOnlyList<IEmployee> GetSubordinates();
}
