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
    /// Payable interface to calculate the payment amount of an employee.
    /// </summary>
    public interface IPayable
    {
        decimal GetPaymentAmount(); 
    } 
}
