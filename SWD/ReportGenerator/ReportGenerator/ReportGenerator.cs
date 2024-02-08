using System;
using System.Collections.Generic;

namespace ReportGenerator
{
    internal abstract class ReportGenerator
    {
        private readonly EmployeeDB _employeeDb;
        protected readonly List<Employee> Employees;
        
        public ReportGenerator(EmployeeDB employeeDb)
        {
            if (employeeDb == null) throw new ArgumentNullException("employeeDb");
            _employeeDb = employeeDb;
            Employees = new List<Employee>();
        }
        
        protected void ExtractDatabase()
        {
            Employee employee;

            _employeeDb.Reset();

            // Get all employees
            while ((employee = _employeeDb.GetNextEmployee()) != null)
            {
                Employees.Add(employee);
            }
        }

        public abstract void CompileReport();
    }
}