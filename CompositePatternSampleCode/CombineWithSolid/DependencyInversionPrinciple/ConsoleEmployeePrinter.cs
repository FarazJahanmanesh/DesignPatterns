namespace CompositePatternSampleCode.CombineWithSolid.DependencyInversionPrinciple;

public class ConsoleEmployeePrinter : IEmployeePrinter
{
    public void Print(IEmployeeBase employee)
    {
        DisplayEmployeeHierarchy(employee);
    }

    private void DisplayEmployeeHierarchy(IEmployeeBase employee, int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 4)}- {employee.Name} ({employee.Position}): {employee.Salary:C}");
        if (employee is IManageSubordinates manager)
        {
            foreach (var sub in manager.GetSubordinates())
            {
                DisplayEmployeeHierarchy(sub, depth + 1);
            }
        }
    }
}
