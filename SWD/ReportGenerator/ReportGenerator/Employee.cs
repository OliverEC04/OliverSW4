namespace ReportGenerator
{
    public class Employee
    {
        public Employee() : this("", 0, 0)
        {
        }

        public Employee(string name, uint salary, int age)
        {
            Name = name;
            Salary = salary;
            Age = age;
        }

        public string Name { get; private set; }
        public uint Salary { get; private set; }
        public int Age { get; private set; }
    }
}