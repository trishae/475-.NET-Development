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
using System.Threading;

namespace Lab2_Stocks
{
    /// <summary>
    /// Notification delegate representing a stock event.
    /// </summary>
    public delegate void StockNotification(string stockName, double currentValue, int numberChanges);



    /// <summary>
    /// Stock Class that represents a stock.
    /// A stock is capital raised by a business via public issue
    /// and subscription of its shares.
    /// </summary>
    public class Stock
    {
        /* ********* Fields ********* */

        /// <summary>
        /// Wait time in milliseconds before a stock's value is modified
        /// </summary>
        private const int IntervalInMilliSec = 500;

        /// <summary>
        /// The number of times a stock is modified
        /// </summary>
        private const int Modifications = 100;

        /// <summary>
        /// Lighweight process object representing stock processing
        /// </summary>
        private Thread thread;

        /// <summary>
        /// Object required to generate random double
        /// </summary>
        private Random rand;

        /// <summary>
        /// The name of a stock
        /// </summary>
        /// <value>The name of the stock.</value>
        public string StockName { get; private set; }

        /// <summary>
        /// The starting value of a stock
        /// </summary>
        /// <value>The initial value.</value>
        public int InitialValue { get; private set; }

        /// <summary>
        /// The range within a stock can change every time unit
        /// </summary>
        /// <value>The max change.</value>
        public double MaxChange { get; private set; }

        /// <summary>
        /// The threshold above or below  which the collection of brokers 
        /// who control the stock must be notified
        /// </summary>
        /// <value>The threshold.</value>
        public double Threshold { get; private set; }

        /// <summary>
        /// The updated value of a stock
        /// </summary>
        /// <value>The current value.</value>
        public double CurrentValue { get; private set; }

        /// <summary>
        /// The number of changes from its initial value if more than 
        /// the specified notification threshold
        /// </summary>
        /// <value>The number changes.</value>
        public int NumberChanges { get; private set; }



        /* ********* Constructors ********* */

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lab2_Stocks.Stock"/> 
        /// class.
        /// </summary>
        /// <param name="stockName">Stock name.</param>
        /// <param name="initialValue">Initial value.</param>
        /// <param name="maxChange">Max change.</param>
        /// <param name="threshold">Threshold.</param>
        public Stock(string stockName, int initialValue, 
                     double maxChange, double threshold)
        {
            StockName = stockName;
            InitialValue = initialValue;
            MaxChange = maxChange;
            Threshold = threshold;

            CurrentValue = InitialValue;
            NumberChanges = 0;

            rand = new Random();
            thread = new Thread(new ThreadStart(Activate));
            thread.Start();
        }



        /* ********* Methods ********* */

        /// <summary>
        /// Method starts the thread of stock processing
        /// </summary>
        public void Activate()
        {
            lock (this)
            {
                for (int i = 0; i < Modifications; i++)
                {
                    ChangeStockValue();
                    Thread.Sleep(IntervalInMilliSec); // Sleep
                }
            }
            thread.Abort(); //destroy thread
        }

        /// <summary>
        /// Method updates the value of a stock
        /// </summary>
        private void ChangeStockValue()
        {
            CurrentValue += rand.NextDouble() * (MaxChange - 1.0) + 1.0;
            if ((CurrentValue - InitialValue) > Threshold)
            {
                NumberChanges += 1;
                OnRaiseStockEvent(new StockInfoEvent(StockName, CurrentValue, NumberChanges));
            }
        }

        /// <summary>
        /// Method invokes a notification event if the difference between
        /// a stock's current and initial value is greater than
        /// a specified threshold
        /// </summary>
        /// <param name="e">E.</param>
        private void OnRaiseStockEvent(StockInfoEvent e)
        {
            if (StockEvent != null)
            {
                StockEvent(e.StockName, e.CurrentValue, e.NumberChanges);
            }
        }

        /// <summary>
        /// Occurs when a stock event is evoked
        /// </summary>
        public event StockNotification StockEvent;
    }
}

