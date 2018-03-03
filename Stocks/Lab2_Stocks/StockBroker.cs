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
using System.IO;
using System.Collections.Generic;

namespace Lab2_Stocks
{
    /// <summary>
    /// StockBroker class that represents a stock broker.
    /// A stock broker is a person who buys ans sells securities
    /// listed on the stock market.
    /// </summary>
    public class StockBroker
    {
        /* ********* Fields ********* */

        /// <summary>
        /// The name of the stock broker
        /// </summary>
        /// <value>The name of the broker.</value>
        public string BrokerName { get; private set; }

        /// <summary>
        /// The collection of stocks owned by a broker
        /// </summary>
        /// <value>The stocks.</value>
        public List<Stock> Stocks { get; private set; }



        /* ********* Constructors ********* */

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="T:Lab2_Stocks.StockBroker"/> class.
        /// </summary>
        /// <param name="brokerName">Broker name.</param>
        public StockBroker(String brokerName)
        {
            BrokerName = brokerName;
            Stocks = new List<Stock>();
        }



        /* ********* Methods ********* */

        /// <summary>
        /// Method adds a stock to a broker's collection
        /// </summary>
        /// <param name="myStock">My stock.</param>
        public void AddStock(Stock myStock)
        {
            Stocks.Add(myStock);
            myStock.StockEvent += Notify;
        }

        /// <summary>
        /// Method outputs stock changes
        /// </summary>
        /// <returns>The notify.</returns>
        /// <param name="stockName">Stock name.</param>
        /// <param name="currentValue">Current value.</param>
        /// <param name="numberChanges">Number changes.</param>
        private void Notify(string stockName, double currentValue, int numberChanges)
        {
            Console.Write("{0,-10}{1,-12}{2,-8:c}{3,-8}\n", this.BrokerName, stockName, currentValue, numberChanges);
            Output(this.BrokerName, stockName, currentValue, numberChanges);
        }

        /// <summary>
        /// Method outputs to text file
        /// </summary>
        /// <returns>The output.</returns>
        /// <param name="brokerName">Broker name.</param>
        /// <param name="stockName">Stock name.</param>
        /// <param name="currentValue">Current value.</param>
        /// <param name="numberChanges">Number changes.</param>
        private async void Output(string brokerName, string stockName, double currentValue, int numberChanges)
        {
            using (var sw = new StreamWriter(@"Stock.txt"))
            {
                await sw.WriteAsync(brokerName + "\t\t" + stockName + "\t\t" + String.Format("{0:C}", currentValue) + "\t\t" + numberChanges);
            }
        }
    }
}
