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

namespace Lab2_Stocks
{
    /// <summary>
    /// Program point-of-entry
    /// </summary>
    class StockApplication
    {
        static void Main(string[] args)
        {
            Stock stock1 = new Stock("Tech", 160, 5.0, 15.0);
            Stock stock2 = new Stock("Retail", 30, 2.0, 6.0);
            Stock stock3 = new Stock("Banking", 90, 4.0, 10.0);
            Stock stock4 = new Stock("Commodity", 500, 20.0, 50.0);

            StockBroker b1 = new StockBroker("Broker 1");
            b1.AddStock(stock1);
            b1.AddStock(stock2);

            StockBroker b2 = new StockBroker("Broker 2");
            b2.AddStock(stock1);
            b2.AddStock(stock3);
            b2.AddStock(stock4);

            StockBroker b3 = new StockBroker("Broker 3");
            b3.AddStock(stock1);
            b3.AddStock(stock3);

            StockBroker b4 = new StockBroker("Broker 4");
            b4.AddStock(stock1);
            b4.AddStock(stock2);
            b4.AddStock(stock3);
            b4.AddStock(stock4);

            // Display Header
            Console.Write("{0,-10}{1,-12}{2,-8:c}{3,-8}\n", "Broker", "Stock", "Value", "Changes");
            FirstOutput("Broker\t\tStock\t\tValue\t\tChanges\n");
        }
        private static async void FirstOutput(string line)
        {
            using (StreamWriter outputFile = new StreamWriter(@"Stocks.txt"))
            {
                await outputFile.WriteAsync(line);
            }
        }
    }
}
