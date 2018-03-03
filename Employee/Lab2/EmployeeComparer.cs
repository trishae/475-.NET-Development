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

namespace Lab2
{
    /// <summary>
    /// Implementation details of IComparer.Compare() that compares
    /// payment amount between two employees.
    /// </summary>
    public class EmployeeComparer : IComparer<Employee>
    {
        /// <summary>
        /// Compare the payment amounts as specified by a and b.
        /// </summary>
        /// <returns>The compare.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public int Compare(Employee a, Employee b)
        {
            if (a.GetPaymentAmount() > b.GetPaymentAmount())
                return 1;

            if (a.GetPaymentAmount() < b.GetPaymentAmount())
                return -1;

            else return 0;
        }
    }
}
