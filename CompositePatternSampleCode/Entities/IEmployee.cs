namespace CompositePatternSampleCode.Entities;

// رابط مشترک برای تمام کارمندان (Component)

//یک رابط مشترک یا کلاس انتزاعی که هم
//Leaf و هم Composite
//از آن تبعیت می‌کنند

public interface IEmployee
{
    string Name { get; }
    string Position { get; }
    double Salary { get; }
    void DisplayDetails(int depth = 0);
    double CalculateTotalSalary();
}