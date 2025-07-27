using System.Text.Json;
namespace CompositePatternSampleCode.CombineWithSolid.OpenClosedPrinciple;


public class JsonEmployeePrinter : IEmployeePrinter
{
    public void Print(IEmployee employee)
    {
        var json = JsonSerializer.Serialize(ToDto(employee), new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(json);
    }

    private object ToDto(IEmployee employee)
    {
        return new
        {
            employee.Name,
            employee.Position,
            employee.Salary,
            Subordinates = employee.GetSubordinates().Select(ToDto).ToList()
        };
    }
}
