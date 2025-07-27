namespace CompositePatternSampleCode.CombineWithSolid.OpenClosedPrinciple;

public class ConsoleEmployeePrinter : IEmployeePrinter
{
    public void Print(IEmployee employee)
    {
        PrintRecursive(employee, 0);
    }

    private void PrintRecursive(IEmployee employee, int depth)
    {
        Console.WriteLine($"{new string(' ', depth * 4)}- {employee.Name} ({employee.Position}): {employee.Salary:C}");
        foreach (var sub in employee.GetSubordinates())
        {
            PrintRecursive(sub, depth + 1);
        }
    }
}
