using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.WEEK5.Day2
{
      class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
       public Employee(string name,double baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }
        public virtual double CalculateSalary()
        {
            return BaseSalary;
        }
    }
    class Manager : Employee
    {
       public  Manager(string Name, double BaseSalary) : base(Name, BaseSalary) { }
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 20/100);
        }
    }
    class Developer : Employee
    {
       public Developer(string Name, double BaseSalary) : base(Name, BaseSalary) { }
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 10 / 100);
        }
    }
    internal class Task2Employee
    {
        static void Main()
        {
            Employee e;
            e = new Manager("jhon", 50000);
            Console.WriteLine("Manager Salary = " + e.CalculateSalary());
            e = new Developer("sara", 50000);
            Console.WriteLine("Manager Salary = " + e.CalculateSalary());
        }
    }
}
