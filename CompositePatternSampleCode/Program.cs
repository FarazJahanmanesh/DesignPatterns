using SRP = CompositePatternSampleCode.CombineWithSolid.SingleResponsibilityPrinciple;
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


        /////////solid ==> S

        SRP.IEmployee dev1SRP = new SRP.Employee("Reza Eilka", "Senior Developer", 150_000_000);
        SRP.IEmployee dev2SRP = new SRP.Employee("Faraz JahanManesh", "Developer", 1_000);
        SRP.IEmployee seSRP = new SRP.Employee("Poryia Karimi", "Software engineer", 150_000_000);
        SRP.IEmployee accSRP = new SRP.Employee("Asad Ahmadi", "Accountant", 180_000_000);
        SRP.IEmployee designerSRP = new SRP.Employee("Poryia Karimi", "UI/UX Designer", 150_000_000);

        SRP.Manager techLeadSRP = new SRP.Manager("Erfan Darvishian", "Technical Lead", 200_000_000);
        SRP.Manager financeManagerSRP = new SRP.Manager("Mohammad Javad Hoshmandan", "Finance Manager", 200_000_000);
        SRP.Manager ctoSRP = new SRP.Manager("Ali Masaeli", "Chief Technology Officer", 300_000_000);
        SRP.Manager ceoSRP = new SRP.Manager("Akbar Azad", "Chief Executive Officer", 500_000_000);

        // ساختاردهی
        techLeadSRP.AddSubordinate(dev1SRP);
        techLeadSRP.AddSubordinate(dev2SRP);
        techLeadSRP.AddSubordinate(seSRP);

        financeManagerSRP.AddSubordinate(accSRP);

        ctoSRP.AddSubordinate(techLeadSRP);
        ctoSRP.AddSubordinate(designerSRP);

        ceoSRP.AddSubordinate(ctoSRP);
        ceoSRP.AddSubordinate(financeManagerSRP);

        // نمایش
        var printer = new SRP.OrganizationPrinter();
        Console.WriteLine("Company Organizational Structure:\n");
        printer.Print(ceoSRP);

        Console.WriteLine("\nTotal Company Salary: " + ceoSRP.CalculateTotalSalary().ToString("C"));




    }
}