namespace ReportGenerator;

internal class SalaryReportGenerator : ReportGenerator
{
    public SalaryReportGenerator(EmployeeDB employeeDb) : base(employeeDb)
    {}
    
    public override void CompileReport()
    {
        ExtractDatabase();
        
        Console.WriteLine("Salary-first report");
        foreach (var e in Employees)
        {
            Console.WriteLine("------------------");
            Console.WriteLine($"Salary: {e.Salary}");
            Console.WriteLine($"Name: {e.Name}");
            Console.WriteLine($"Age: {e.Age}");
            Console.WriteLine("------------------");
        }
    }
}