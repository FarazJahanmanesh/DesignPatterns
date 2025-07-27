namespace CompositePatternSampleCode.Entities;

// رابط مشترک برای تمام کارمندان
public interface IEmployee
{
    string Name { get; }
    string Position { get; }
    double Salary { get; }
    void DisplayDetails(int depth = 0);
    double CalculateTotalSalary();
}