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
    /// Abstract class of Employee.  
    /// 
    /// Fields are only First Name, Last Name, and Social Security Number. 
    /// Class implements IComparable interface and referenced method 
    /// (via delegate in Program class). 
    /// 
    /// Employee class has children derivatives.
    /// </summary>
    public abstract class Employee : IPayable, IComparable<Employee>
    {
        // Fields //
        /// <summary>
        /// First name property of an employee.
        public string FirstName { get; private set; }

        /// <summary>
        /// Last name property of an employee.
        public string LastName { get; private set; }

        /// <summary>
        /// Social Security Number property of an employee.
        public string SocialSecurityNumber { get; private set; }

       
        // Constructors //
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lab2.Employee"/> class.
        /// </summary>
        /// <param name="first">First.</param>
        /// <param name="last">Last.</param>
        /// <param name="ssn">Ssn.</param>
        public Employee(string first, string last, string ssn)
        {
            FirstName = first;
            LastName = last;
            SocialSecurityNumber = ssn;
        } 


        // Methods //
        /// <summary>
        /// Gets the payment amount of an employee.
        /// </summary>
        /// <returns>The payment amount.</returns>
        public abstract decimal GetPaymentAmount();

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current 
        /// <see cref="T:Lab2.Employee"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current 
        /// <see cref="T:Lab2.Employee"/>.</returns>
        public override string ToString()
        {
            return string.Format("{0} {1}\nsocial security number: {2}",
               FirstName, LastName, SocialSecurityNumber);
        }

        /// <summary>
        /// Provides implementation details to IComparable.CompareTo that 
        /// compares last names of two employees.
        /// </summary>
        /// <returns>The to.</returns>
        /// <param name="other">Other.</param>
        public int CompareTo(Employee other)
        {
            return other.LastName.CompareTo((this.LastName));
        }

        /// <summary>
        /// Compares social security numbers in string format of two employees
        /// and returns a boolean value.
        /// </summary>
        /// <returns><c>true</c>, if s greater was BSSNIed, <c>false</c> otherwise.</returns>
        /// <param name="a">The alpha component.</param>
        /// <param name="b">The blue component.</param>
        public static bool BSSNIsGreater(Employee a, Employee b)
        {
            return (a.SocialSecurityNumber.CompareTo(b.SocialSecurityNumber) < 0);
        }
    } // end abstract class Employee
}
