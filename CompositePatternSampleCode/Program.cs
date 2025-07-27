using CompositePatternSampleCode.Entities;
namespace CompositePatternSampleCode;

class Program
{
    static void Main()
    {
        // ایجاد کارمندان ساده
        IEmployee developer1 = new Employee("Reza Eilka", "Senior Developer", 150_000_000);
        IEmployee developer2 = new Employee("Faraz JahanManesh", "Developer", 1_000);
        IEmployee SoftwareEngineer = new Employee("Poryia Karimi", "Software engineer", 150_000_000);
        IEmployee accountant = new Employee("Asad Ahmadi", "Accountant", 180_000_000);
        IEmployee designer = new Employee("Poryia Karimi", "UI/UX Designer", 150_000_000);

        // ایجاد مدیران
        Manager techLead = new Manager("Erfan Darvishian", "Technical Lead", 200_000_000);
        Manager financeManager = new Manager("Mohammad Javad Hoshmandan", "Finance Manager", 200_000_000);
        Manager cto = new Manager("Ali Masaeli", "Chief Technology Officer", 300_000_000);
        Manager ceo = new Manager("Akbar Azad", "Chief Executive Officer", 500_000_000);

        // ایجاد ساختار سلسله مراتبی
        techLead.AddSubordinate(developer1);
        techLead.AddSubordinate(developer2);
        techLead.AddSubordinate(SoftwareEngineer);

        financeManager.AddSubordinate(accountant);

        cto.AddSubordinate(techLead);
        cto.AddSubordinate(designer);

        ceo.AddSubordinate(cto);
        ceo.AddSubordinate(financeManager);

        // نمایش ساختار سازمانی
        Console.WriteLine("Company Organizational Structure:\n");
        ceo.DisplayDetails();

        // محاسبه کل حقوق شرکت
        Console.WriteLine("\nTotal Company Salary: " + ceo.CalculateTotalSalary().ToString("C"));
    }
}