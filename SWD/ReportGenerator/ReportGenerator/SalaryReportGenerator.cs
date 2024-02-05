namespace ReportGenerator;

public class SalaryReportGenerator : IReportGenerator
{
    public void CompileReport(List<Employee> employees)
    {
        Console.WriteLine("Salary-first report");
        foreach (var e in employees)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Salary: {0}", e.Salary);
            Console.WriteLine("Name: {0}", e.Name);
            Console.WriteLine("------------------");
        }
    }
}