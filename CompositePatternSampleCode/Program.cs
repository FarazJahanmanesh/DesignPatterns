using CompositePatternSampleCode.Entities;
using ISP = CompositePatternSampleCode.CombineWithSolid.InterfaceSegregationPrinciple;
using LSP = CompositePatternSampleCode.CombineWithSolid.LiskovSubstitutionPrinciple;
using OCP = CompositePatternSampleCode.CombineWithSolid.OpenClosedPrinciple;
using SRP = CompositePatternSampleCode.CombineWithSolid.SingleResponsibilityPrinciple;
using DIP = CompositePatternSampleCode.CombineWithSolid.DependencyInversionPrinciple;
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


        Console.WriteLine("-------------------------------------------------------------- SingleResponsibilityPrinciple Sample");
        /////////Solid ==> S

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


        Console.WriteLine("-------------------------------------------------------------- OpenClosedPrinciple Sample");
        /////////Solid ==> O

        OCP.IEmployee dev1OCP = new OCP.Employee("Reza Eilka", "Senior Developer", 150_000_000);
        OCP.IEmployee dev2OCP = new OCP.Employee("Faraz JahanManesh", "Developer", 1_000);
        OCP.IEmployee seOCP = new OCP.Employee("Poryia Karimi", "Software engineer", 150_000_000);
        OCP.IEmployee accOCP = new OCP.Employee("Asad Ahmadi", "Accountant", 180_000_000);
        OCP.IEmployee designerOCP = new OCP.Employee("Poryia Karimi", "UI/UX Designer", 150_000_000);

        OCP.Manager techLeadOCP = new OCP.Manager("Erfan Darvishian", "Technical Lead", 200_000_000);
        OCP.Manager financeManagerOCP = new OCP.Manager("Mohammad Javad Hoshmandan", "Finance Manager", 200_000_000);
        OCP.Manager ctoOCP = new OCP.Manager("Ali Masaeli", "Chief Technology Officer", 300_000_000);
        OCP.Manager ceoOCP = new OCP.Manager("Akbar Azad", "Chief Executive Officer", 500_000_000);

        // ساختاردهی
        techLeadOCP.AddSubordinate(dev1OCP);
        techLeadOCP.AddSubordinate(dev2OCP);
        techLeadOCP.AddSubordinate(seOCP);

        financeManagerOCP.AddSubordinate(accOCP);

        ctoOCP.AddSubordinate(techLeadOCP);
        ctoOCP.AddSubordinate(designerOCP);

        ceoOCP.AddSubordinate(ctoOCP);
        ceoOCP.AddSubordinate(financeManagerOCP);

        // انتخاب نوع نمایش
        OCP.IEmployeePrinter printerOCP = new OCP.ConsoleEmployeePrinter();
        printerOCP.Print(ceoOCP);

        Console.WriteLine("\n----- نمایش JSON -----\n");
        OCP.IEmployeePrinter jsonPrinter = new OCP.JsonEmployeePrinter();
        jsonPrinter.Print(ceoOCP);

        Console.WriteLine("\nTotal Company Salary: " + ceoOCP.CalculateTotalSalary().ToString("C"));


        Console.WriteLine("-------------------------------------------------------------- LiskovSubstitutionPrinciple Sample");
        /////////Solid ==> L

        // 🔹 ساخت کارمندهای ساده (Leaf)
        LSP.IEmployee dev1LSP = new LSP.Employee("Reza Eilka", "Senior Developer", 150_000_000);
        LSP.IEmployee dev2LSP = new LSP.Employee("Faraz JahanManesh", "Developer", 1_000);
        LSP.IEmployee seLSP = new LSP.Employee("Poryia Karimi", "Software Engineer", 150_000_000);
        LSP.IEmployee accLSP = new LSP.Employee("Asad Ahmadi", "Accountant", 180_000_000);
        LSP.IEmployee designerLSP = new LSP.Employee("Poryia Karimi", "UI/UX Designer", 150_000_000);

        // 🔹 ساخت مدیرها (Composite)
        LSP.Manager techLeadLSP = new LSP.Manager("Erfan Darvishian", "Technical Lead", 200_000_000);
        LSP.Manager financeManagerLSP = new LSP.Manager("Mohammad Javad Hoshmandan", "Finance Manager", 200_000_000);
        LSP.Manager ctoLSP = new LSP.Manager("Ali Masaeli", "Chief Technology Officer", 300_000_000);
        LSP.Manager ceoLSP = new LSP.Manager("Akbar Azad", "Chief Executive Officer", 500_000_000);

        // 🔹 ایجاد ساختار سلسله‌مراتبی
        techLeadLSP.AddSubordinate(dev1LSP);
        techLeadLSP.AddSubordinate(dev2LSP);
        techLeadLSP.AddSubordinate(seLSP);

        financeManagerLSP.AddSubordinate(accLSP);

        ctoLSP.AddSubordinate(techLeadLSP);
        ctoLSP.AddSubordinate(designerLSP);

        ceoLSP.AddSubordinate(ctoLSP);
        ceoLSP.AddSubordinate(financeManagerLSP);

        Console.WriteLine("Organizational Structure (LSP):\n");
        DisplayEmployeeHierarchy(ceoLSP);

        Console.WriteLine("\nTotal Company Salary: " + ceoLSP.CalculateTotalSalary().ToString("C"));

        Console.WriteLine("\nCTO's Subordinates:");
        foreach (var sub in ctoLSP.GetSubordinates())
        {
            Console.WriteLine($"- {sub.Name} ({sub.Position})");
        }

        Console.WriteLine("\nSubordinates of a simple Employee:");
        foreach (var sub in dev1LSP.GetSubordinates()) 
        {
            Console.WriteLine($"- {sub.Name} ({sub.Position})");
        }


        Console.WriteLine("-------------------------------------------------------------- InterfaceSegregationPrinciple Sample");
        /////////Solid ==> I

        // 🔹 ساخت کارمندهای ساده (Leaf)
        ISP.IEmployeeBase dev1ISP = new ISP.Employee("Reza Eilka", "Senior Developer", 150_000_000);
        ISP.IEmployeeBase dev2ISP = new ISP.Employee("Faraz JahanManesh", "Developer", 1_000);
        ISP.IEmployeeBase seISP = new ISP.Employee("Poryia Karimi", "Software Engineer", 150_000_000);
        ISP.IEmployeeBase accISP = new ISP.Employee("Asad Ahmadi", "Accountant", 180_000_000);
        ISP.IEmployeeBase designerISP = new ISP.Employee("Poryia Karimi", "UI/UX Designer", 150_000_000);

        // 🔹 ساخت مدیرها (Composite)
        ISP.Manager techLeadISP = new ISP.Manager("Erfan Darvishian", "Technical Lead", 200_000_000);
        ISP.Manager financeManagerISP = new ISP.Manager("Mohammad Javad Hoshmandan", "Finance Manager", 200_000_000);
        ISP.Manager ctoISP = new ISP.Manager("Ali Masaeli", "Chief Technology Officer", 300_000_000);
        ISP.Manager ceoISP = new ISP.Manager("Akbar Azad", "Chief Executive Officer", 500_000_000);

        // 🔹 ایجاد ساختار سلسله‌مراتبی (از طریق IManageSubordinates)
        ISP.IManageSubordinates techLeadManager = techLeadISP;
        techLeadManager.AddSubordinate(dev1ISP);
        techLeadManager.AddSubordinate(dev2ISP);
        techLeadManager.AddSubordinate(seISP);

        ISP.IManageSubordinates financeManager2 = financeManagerISP;
        financeManager2.AddSubordinate(accISP);

        ISP.IManageSubordinates ctoManager = ctoISP;
        ctoManager.AddSubordinate(techLeadISP);
        ctoManager.AddSubordinate(designerISP);

        ISP.IManageSubordinates ceoManager = ceoISP;
        ceoManager.AddSubordinate(ctoISP);
        ceoManager.AddSubordinate(financeManagerISP);

        // ✅ نمایش ساختار سازمانی
        Console.WriteLine("Organizational Structure (ISP):\n");
        DisplayEmployeeHierarchyISP(ceoISP);

        // ✅ محاسبه کل حقوق شرکت
        Console.WriteLine("\nTotal Company Salary: " + ceoISP.CalculateTotalSalary().ToString("C"));

        // ✅ دسترسی به زیرمجموعه‌ها (از طریق IManageSubordinates)
        Console.WriteLine("\nCTO's Subordinates:");
        foreach (var sub in ctoManager.GetSubordinates())
        {
            Console.WriteLine($"- {sub.Name} ({sub.Position})");
        }

        Console.WriteLine("\nSubordinates of a simple Employee:");
        // چون Employee ساده زیرمجموعه ندارد، فقط به IEmployeeBase دسترسی دارد، پس باید چک کنیم:
        if (dev1ISP is ISP.IManageSubordinates dev1Manager)
        {
            foreach (var sub in dev1Manager.GetSubordinates())
            {
                Console.WriteLine($"- {sub.Name} ({sub.Position})");
            }
        }
        else
        {
            Console.WriteLine("No subordinates.");
        }



        Console.WriteLine("-------------------------------------------------------------- DependencyInversionPrinciple Sample");
        /////////Solid ==> D

        // 🔹 همه جا از Interfaceها استفاده می‌کنیم
        DIP.IEmployeeBase dev1DIP = new DIP.Employee("Reza Eilka", "Senior Developer", 150_000_000);
        DIP.IEmployeeBase dev2DIP = new DIP.Employee("Faraz JahanManesh", "Developer", 1_000);
        DIP.IEmployeeBase seDIP = new DIP.Employee("Poryia Karimi", "Software Engineer", 150_000_000);
        DIP.IEmployeeBase accDIP = new DIP.Employee("Asad Ahmadi", "Accountant", 180_000_000);
        DIP.IEmployeeBase designerDIP = new DIP.Employee("Poryia Karimi", "UI/UX Designer", 150_000_000);

        DIP.IManageSubordinates techLeadDIP = new DIP.Manager("Erfan Darvishian", "Technical Lead", 200_000_000);
        DIP.IManageSubordinates financeManagerDIP = new DIP.Manager("Mohammad Javad Hoshmandan", "Finance Manager", 200_000_000);
        DIP.IManageSubordinates ctoDIP = new DIP.Manager("Ali Masaeli", "Chief Technology Officer", 300_000_000);
        DIP.IManageSubordinates ceoDIP = new DIP.Manager("Akbar Azad", "Chief Executive Officer", 500_000_000);

        // 🔹 ساختاردهی بدون اینکه به کلاس‌ها بچسبیم
        techLeadDIP.AddSubordinate(dev1DIP);
        techLeadDIP.AddSubordinate(dev2DIP);
        techLeadDIP.AddSubordinate(seDIP);

        financeManagerDIP.AddSubordinate(accDIP);

        ctoDIP.AddSubordinate((DIP.IEmployeeBase)techLeadDIP);
        ctoDIP.AddSubordinate(designerDIP);

        ceoDIP.AddSubordinate((DIP.IEmployeeBase)ctoDIP);
        ceoDIP.AddSubordinate((DIP.IEmployeeBase)financeManagerDIP);

        // 🔹 حالا چاپگر رو از بیرون تزریق می‌کنیم
        DIP.IEmployeePrinter printerDIP = new DIP.ConsoleEmployeePrinter();
        printerDIP.Print((DIP.IEmployeeBase)ceoDIP);

        Console.WriteLine("\n----- JSON Output -----\n");
        DIP.IEmployeePrinter jsonPrinterDIP = new DIP.JsonEmployeePrinter();
        jsonPrinterDIP.Print((DIP.IEmployeeBase)ceoDIP);

        // 🔹 محاسبه کل حقوق
        Console.WriteLine("\nTotal Company Salary: " +
            ((DIP.IEmployeeBase)ceoDIP).CalculateTotalSalary().ToString("C"));

    }
    static void DisplayEmployeeHierarchy(LSP.IEmployee employee, int depth = 0)
    {
        Console.WriteLine($"{new string(' ', depth * 4)}- {employee.Name} ({employee.Position}): {employee.Salary:C}");
        foreach (var sub in employee.GetSubordinates())
        {
            DisplayEmployeeHierarchy(sub, depth + 1);
        }
    }
    static void DisplayEmployeeHierarchyISP(ISP.IEmployeeBase employee, int depth = 0)
    {
        // نمایش اطلاعات کارمند فعلی
        Console.WriteLine($"{new string(' ', depth * 4)}- {employee.Name} ({employee.Position}): {employee.Salary:C}");

        // اگر این کارمند زیرمجموعه‌پذیر بود (Composite)
        if (employee is ISP.IManageSubordinates manager)
        {
            foreach (var sub in manager.GetSubordinates())
            {
                DisplayEmployeeHierarchyISP(sub, depth + 1);
            }
        }
    }
}