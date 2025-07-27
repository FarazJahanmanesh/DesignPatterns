namespace CompositePatternSampleCode.CombineWithSolid.InterfaceSegregationPrinciple;

public interface IManageSubordinates
{
    void AddSubordinate(IEmployeeBase employee);
    void RemoveSubordinate(IEmployeeBase employee);
    IEnumerable<IEmployeeBase> GetSubordinates();
}
