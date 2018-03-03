// @author      Trisha Echual
// studentID    013470806
// 
//              CECS 475 Software Frameworks
//              Professor Phuong Nguyen
//
// @date        February 13, 2018
//              Lab 2
using System;
namespace Lab2
{
    /// <summary>
    /// Salaried employee extending the employee abstract class.
    /// </summary>
    public class SalariedEmployee : Employee
    {
        private decimal weeklySalary;

        // four-parameter constructor
        public SalariedEmployee(string first, string last, string ssn,
           decimal salary) : base(first, last, ssn)
        {
            WeeklySalary = salary; // validate salary via property
        } // end four-parameter SalariedEmployee constructor

        // property that gets and sets salaried employee's salary
        public decimal WeeklySalary
        {
            get
            {
                return weeklySalary;
            } // end get
            set
            {
                if (value >= 0) // validation
                    weeklySalary = value;
                else
                    throw new ArgumentOutOfRangeException("WeeklySalary",
                       value, "WeeklySalary must be >= 0");
            } // end set
        } // end property WeeklySalary

        // calculate earnings; override abstract method Earnings in Employee
        public override decimal GetPaymentAmount()
        {
            return WeeklySalary;
        } // end method Earnings          

        // return string representation of SalariedEmployee object
        public override string ToString()
        {
            return string.Format("salaried employee: {0}\n{1}: {2:C}",
               base.ToString(), "weekly salary", WeeklySalary);
        } // end method ToString                                      
    } // end class SalariedEmployee
}
