using System;

namespace ReportGenerator
{
    internal class ReportGeneratorClient
    {
        private static void Main()
        {
            var db = new EmployeeDB();

            // Add some employees
            db.AddEmployee(new Employee("Anne", 3000, 21));
            db.AddEmployee(new Employee("Berit", 2000, 69));
            db.AddEmployee(new Employee("Christel", 1000, 11));

            var nameReportGenerator = new NameReportGenerator(db);
            var salaryReportGenerator = new SalaryReportGenerator(db);
            var ageReportGenerator = new AgeReportGenerator(db);

            // Create a default (name-first) report
            nameReportGenerator.CompileReport();

            Console.WriteLine("");
            Console.WriteLine("");

            // Create a salary-first report
            salaryReportGenerator.CompileReport();
            
            Console.WriteLine("");
            Console.WriteLine("");

            // Create a age-first report
            ageReportGenerator.CompileReport();
        }
    }
}