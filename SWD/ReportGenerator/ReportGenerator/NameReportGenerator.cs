namespace ReportGenerator;

public class NameReportGenerator : IReportGenerator
{
    public NameReportGenerator(EmployeeDB employeeDb)
    {
        
    }
    
    public void CompileReport(List<Employee> employees)
    {
        Console.WriteLine("Name-first report");
        foreach (var e in employees)
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Name: {0}", e.Name);
            Console.WriteLine("Salary: {0}", e.Salary);
            Console.WriteLine("------------------");
        }
    }
}