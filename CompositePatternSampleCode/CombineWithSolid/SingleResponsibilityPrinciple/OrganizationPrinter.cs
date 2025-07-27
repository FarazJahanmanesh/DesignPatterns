namespace CompositePatternSampleCode.CombineWithSolid.SingleResponsibilityPrinciple;

public class OrganizationPrinter
{
    public void Print(IEmployee employee, int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 4)}- {employee.Name} ({employee.Position}): {employee.Salary:C}");
        foreach (var sub in employee.GetSubordinates())
        {
            Print(sub, depth + 1);
        }
    }
}
