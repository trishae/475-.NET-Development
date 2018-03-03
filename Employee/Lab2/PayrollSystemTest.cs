// @author      Trisha Echual
// studentID    013470806
// 
//              CECS 475 Software Frameworks
//              Professor Phuong Nguyen
//
// @date        February 13, 2018
//              Lab 2
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab2
{
    /// <summary>
    /// Program entry point including test values for Employees.
    /// Program provides menu options to sort through Employee data against a 
    /// specified field.
    /// </summary>
    public class PayrollSystemTest
    {
        /// <summary>
        /// Compare delegate referencing Employee.BSSNIsGreater() method.
        /// </summary>
        public delegate bool CompareDelegate(Employee a, Employee b);

        /// <summary>
        /// The entry point of the program, where the program control starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static void Main(string[] args)
        {
            SalariedEmployee salariedEmployee =
               new SalariedEmployee("John", "Smith", "111-11-1111", 800.00M);
            
            HourlyEmployee hourlyEmployee =
               new HourlyEmployee("Karen", "Price",
               "222-22-2222", 16.75M, 40.0M);
            
            CommissionEmployee commissionEmployee =
               new CommissionEmployee("Sue", "Jones",
               "333-33-3333", 10000.00M, .06M);
            
            BasePlusCommissionEmployee basePlusCommissionEmployee =
               new BasePlusCommissionEmployee("Bob", "Lewis",
               "444-44-4444", 5000.00M, .04M, 300.00M);
            
            Console.WriteLine("Employees processed individually:\n");

            Console.WriteLine("{0}\nearned: {1:C}\n", salariedEmployee, 
                              salariedEmployee.GetPaymentAmount());
            Console.WriteLine("{0}\nearned: {1:C}\n", hourlyEmployee, 
                              hourlyEmployee.GetPaymentAmount());
            Console.WriteLine("{0}\nearned: {1:C}\n", commissionEmployee, 
                              commissionEmployee.GetPaymentAmount());
            Console.WriteLine("{0}\nearned: {1:C}\n", basePlusCommissionEmployee, 
                              basePlusCommissionEmployee.GetPaymentAmount());

            List<Employee> employees = new List<Employee>();
            employees.Add(salariedEmployee);
            employees.Add(hourlyEmployee);
            employees.Add(commissionEmployee);
            employees.Add(basePlusCommissionEmployee);

            // Add more values for testing purposes
            Console.WriteLine("Adding more values...");
            employees.Add(new SalariedEmployee("John", "Smith", "111-11-1111", 
                                               500M));
            employees.Add(new SalariedEmployee("Antonio", "Smith", "555-55-5555", 
                                               800M));
            employees.Add(new SalariedEmployee("Victor", "Smith", "444-44-4444", 
                                               600M));
            employees.Add(new HourlyEmployee("Karen", "Price", "222-22-2222", 
                                             16.75M, 40M));
            employees.Add(new HourlyEmployee("Ruben", "Zamora", "666-66-6666", 
                                             20.00M, 40M));
            employees.Add(new CommissionEmployee("Sue", "Jones", "333-33-3333", 
                                                 10000M, .06M));
            employees.Add(new BasePlusCommissionEmployee("Bob", "Lewis", "777-77-7777", 
                                                         5000M, .04M, 300M));
            employees.Add(new BasePlusCommissionEmployee("Lee", "Duarte", "888-88-888", 
                                                         5000M, .04M, 300M));
            Console.WriteLine("Successfully added more values...");

            Console.WriteLine("Employees processed polymorphically:\n");

            foreach (Employee currentEmployee in employees)
            {
                Console.WriteLine(currentEmployee); // invokes ToString

                //determine whether element is a BasePlusCommissionEmployee
                if (currentEmployee is BasePlusCommissionEmployee)
                {
                    // downcast Employee reference to 
                    // BasePlusCommissionEmployee reference
                    BasePlusCommissionEmployee employee =
                       (BasePlusCommissionEmployee)currentEmployee;

                    employee.BaseSalary *= 1.10M;
                    Console.WriteLine(
                       "new base salary with 10% increase is: {0:C}",
                        employee.BaseSalary);
                    } // end if
                Console.WriteLine(
                    "earned {0:C}\n", currentEmployee.GetPaymentAmount());
            }

            for (int j = 0; j < employees.Count; j++)
                Console.WriteLine("Employee {0} is a {1}", j, employees[j].GetType());

            // Display menu items for user input
            DisplayMenu(employees);
        }

        /// <summary>
        /// Method provides menu items for user to choose from.
        /// </summary>
        /// <param name="employees">Employees.</param>
        public static void DisplayMenu(List<Employee> employees)
        {
            int userInput = 1;
            int maxChoice = 4;

            while (userInput <= maxChoice && userInput > 0)
            {
                Console.WriteLine("\nPick a choice...");
                Console.WriteLine("1. Sort last name in descending order using " +
                                  "IComparable");
                Console.WriteLine("2. Sort pay amount in ascending order using " +
                                  "IComparer");
                Console.WriteLine("3. Sort by social security number in descending " +
                                  "order using a selection sort and delegate");
                Console.WriteLine("4. Sorting last name in ascending order " +
                                  "and pay amount in descending order by using LINQ");
                Console.WriteLine("0. Exit\n");

                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput == 1)
                {
                    employees.Sort();

                    foreach (Employee e in employees)
                    {
                        Console.WriteLine(e.LastName + ", " + e.FirstName);
                    }
                }
                else if (userInput == 2)
                {
                    EmployeeComparer ec = new EmployeeComparer();
                    employees.Sort(ec);

                    foreach (Employee e in employees)
                    {
                        Console.WriteLine(e.LastName + ", " + e.FirstName + " - $" + 
                                          e.GetPaymentAmount());
                    }
                }
                else if (userInput == 3)
                {
                    CompareDelegate EmployeeSSNCompare = new 
                        CompareDelegate(Employee.BSSNIsGreater);
                    BubbleSort.Sort(employees, EmployeeSSNCompare);

                    foreach (Employee e in employees)
                    {
                        Console.WriteLine(e.LastName + ", " + e.FirstName + " - " + 
                                          e.SocialSecurityNumber);
                    }
                }
                else if (userInput == 4)
                {
                    var multiSortingResult = from e in employees
                                             orderby e.LastName ascending, 
                    e.GetPaymentAmount() descending
                                             select e;

                    foreach (Employee i in multiSortingResult)
                    {
                        Console.WriteLine(i.LastName + ", " + i.FirstName + " - $" + 
                                          i.GetPaymentAmount());
                    }
                }
                else if (userInput == 0)
                    return; // Exit point
                else
                {
                    Console.WriteLine("Invalid Input.");
                    userInput = 1;
                }
            }
        }
    }
}
