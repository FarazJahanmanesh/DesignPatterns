namespace CompositePatternSampleCode.CombineWithSolid.DependencyInversionPrinciple;

public interface IManageSubordinates
{
    void AddSubordinate(IEmployeeBase employee);
    void RemoveSubordinate(IEmployeeBase employee);
    IEnumerable<IEmployeeBase> GetSubordinates();
}
