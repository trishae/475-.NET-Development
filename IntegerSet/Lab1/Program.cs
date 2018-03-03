/**
 * @author Trisha Echual
 * studentID 013470806
 * 
 * CECS 475 Software Frameworks
 * Professor Phuong Nguyen
 * 
 * @date January 30, 2018
 */
using System;

namespace Lab1
{
    /// <summary>
    /// Program contains main method.
    /// Program also contains method to allow users to input members 
    /// into a set.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Inserts members inputted by the use into the set.
        /// </summary>
        /// <returns>IntegerSet, the inputted set.</returns>
        private static IntegerSet InputSet()
        {
            IntegerSet temp = new IntegerSet();
            int num = Convert.ToInt32(Console.ReadLine());
            while (num != -1)
            {
                temp.InsertElement(num);
                num = Convert.ToInt32(Console.ReadLine());
            }

            return temp;
        }

        /// <summary>
        /// The entry point of the program, where the program control 
        /// starts and ends.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // initialize two sets
            Console.WriteLine("(NOTE: When inputting, enter -1 to end.\n" +
                              "Negative numbers will not be entered into " +
                              "the set.)\n");
            Console.WriteLine("Input Set A");
            IntegerSet set1 = InputSet();
            Console.WriteLine("\nInput Set B");
            IntegerSet set2 = InputSet();

            IntegerSet union = set1.Union(set2);
            IntegerSet intersection = set1.Intersection(set2);

            // prepare output
            Console.WriteLine("\nSet A contains elements:");
            Console.WriteLine(set1.ToString());
            Console.WriteLine("\nSet B contains elements:");
            Console.WriteLine(set2.ToString());
            Console.WriteLine(
            "\nUnion of Set A and Set B contains elements:");
            Console.WriteLine(union.ToString());
            Console.WriteLine(
            "\nIntersection of Set A and Set B contains elements:");
            Console.WriteLine(intersection.ToString());

            // test whether two sets are equal
            if (set1.IsEqualTo(set2))
                Console.WriteLine("\nSet A is equal to set B");
            else
                Console.WriteLine("\nSet A is not equal to set B");

            // test insert and delete
            Console.WriteLine("\nInserting 77 into set A...");
            set1.InsertElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            Console.WriteLine("\nDeleting 77 from set A...");
            set1.DeleteElement(77);
            Console.WriteLine("\nSet A now contains elements:");
            Console.WriteLine(set1.ToString());

            // test constructor
            int[] intArray = { 25, 67, 2, 9, 99, 105, 45, -5, 100, 1 };
            IntegerSet set3 = new IntegerSet(intArray);

            Console.WriteLine("\nNew Set contains elements:");
            Console.WriteLine(set3.ToString());
        }
    }
}