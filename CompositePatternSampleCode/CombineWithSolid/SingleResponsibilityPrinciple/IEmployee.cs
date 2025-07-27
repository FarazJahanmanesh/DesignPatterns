namespace CompositePatternSampleCode.CombineWithSolid.SingleResponsibilityPrinciple;

//دیگه متد DisplayDetails رو اینجا نمی‌ذاریم.
// فقط مسئول داده و منطق Composite هست.

public interface IEmployee
{
    string Name { get; }
    string Position { get; }
    double Salary { get; }
    double CalculateTotalSalary();
    IReadOnlyList<IEmployee> GetSubordinates();
}
