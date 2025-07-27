namespace CompositePatternSampleCode.CombineWithSolid.DependencyInversionPrinciple;

public class JsonEmployeePrinter : IEmployeePrinter
{
    public void Print(IEmployeeBase employee)
    {
        var json = SerializeEmployee(employee);
        Console.WriteLine(json);
    }

    private object SerializeEmployee(IEmployeeBase employee)
    {
        var obj = new
        {
            employee.Name,
            employee.Position,
            employee.Salary,
            Subordinates = (employee is IManageSubordinates manager)
                ? manager.GetSubordinates().Select(e => SerializeEmployee(e)).ToList()
                : new List<object>()
        };
        return System.Text.Json.JsonSerializer.Serialize(obj, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
    }
}
