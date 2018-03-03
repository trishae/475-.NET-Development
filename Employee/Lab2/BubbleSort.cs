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
using Lab2;

namespace Lab2
{
    /// <summary>
    /// Class that encapsulates the bubble sort algorithm against a list
    /// of Employee objects.
    /// </summary>
    public class BubbleSort
    {
        /// <summary>
        /// Sort employee payment amounts using bubble sort.
        /// </summary>
        /// <returns>The sort.</returns>
        /// <param name="employees">Employees.</param>
        /// <param name="del">Del.</param>
        static public void Sort(List<Employee> employees, PayrollSystemTest.CompareDelegate del)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                for (int j = 0; j < employees.Count; j++)
                {
                    if (del(employees[j], employees[i]))
                    {
                        Employee temp = employees[i];
                        employees[i] = employees[j];
                        employees[j] = temp;
                    }
                }
            }   
        }
    }
}
