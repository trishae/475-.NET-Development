/* Author   Trisha Echual
 *          013470806
 * 
 *          Lab 2 Stocks
 * 
 * Class    CECS 475
 * Lecturer Professor Phuong Nguyen
 * 
 * Date     February 27, 2018
 */
using System;
namespace Lab2_Stocks
{
    /// <summary>
    /// StockInfoEvent class that represents stock information.
    /// StockInfoEvent encapsulates information only needed to invoke
    /// a stock notification event.
    /// </summary>
    public class StockInfoEvent
    {
        /* ********* Fields ********* */

        /// <summary>
        /// The name of the stock
        /// </summary>
        /// <value>The name of the stock.</value>
        public string StockName { get; }

        /// <summary>
        /// The updated value of a stock
        /// </summary>
        /// <value>The current value.</value>
        public double CurrentValue { get; }

        /// <summary>
        /// The number of changes from its initial value if more than 
        /// the specified notification threshold 
        /// </summary>
        /// <value>The number changes.</value>
        public int NumberChanges { get; }



        /* ********* Constructors ********* */

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="T:Lab2_Stocks.StockInfoEvent"/> class.
        /// </summary>
        /// <param name="stockName">Stock name.</param>
        /// <param name="currentValue">Current value.</param>
        /// <param name="numberChanges">Number changes.</param>
        public StockInfoEvent(string stockName, double currentValue, int numberChanges)
        {
            StockName = stockName;
            CurrentValue = currentValue;
            NumberChanges = numberChanges;
        }

        /* ********* Methods ********* */
    }
}
