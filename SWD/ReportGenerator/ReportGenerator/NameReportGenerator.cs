﻿namespace ReportGenerator;

internal class NameReportGenerator : ReportGenerator
{
    public NameReportGenerator(EmployeeDB employeeDb) : base(employeeDb)
    {}
    
    public override void CompileReport()
    {
        ExtractDatabase();
        
        Console.WriteLine("Name-first report");
        foreach (var e in Employees)
        {
            Console.WriteLine("------------------");
            Console.WriteLine($"Name: {e.Name}");
            Console.WriteLine($"Salary: {e.Salary}");
            Console.WriteLine($"Age: {e.Age}");
            Console.WriteLine("------------------");
        }
    }
}