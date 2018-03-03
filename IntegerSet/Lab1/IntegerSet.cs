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
    /// IntegerSet represents a set of integers
    /// </summary>
    /// <remarks>
    /// A set is defined as a collection of non-repeating, non-ordered members.
    /// </remarks>
    public class IntegerSet
    {
        // MEMBERS //

        /// <summary>
        /// The size of the array.
        /// </summary>
        const int arraySize = 100;

        /// <summary>
        /// The set represented by an array of boolean values.
        /// </summary>
        private bool[] set;



        // CONSTRUCTORS //

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lab1.IntegerSet"/> 
        /// class.
        /// </summary>
        public IntegerSet() 
        {
            set = new bool[arraySize];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Lab1.IntegerSet"/> 
        /// class.
        /// </summary>
        /// <param name="a">integer array a.</param>
        public IntegerSet(int[] a):this()
        {
            // Insert element 
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] >= 0 && a[i] < arraySize)
                {
                    InsertElement(a[i]);
                }
            }
                
        }



        // METHODS //

        /// <summary>
        /// Method creates the union of two sets
        /// </summary>
        /// <returns>IntegerSet, the union of this set and s set.</returns>
        /// <param name="s">IntegerSet S.</param>
        public IntegerSet Union(IntegerSet s)
        {
            IntegerSet temp = new IntegerSet();
            for (int i = 0; i < arraySize; i++)
            {
                temp.set[i] = this.set[i] || s.set[i];
            }

            return temp;
        }

        /// <summary>
        /// Method creates the intersection of two sets
        /// </summary>
        /// <returns>IntegerSet, the intersection of this set 
        /// and s set.</returns>
        /// <param name="s">IntegerSet S.</param>
        public IntegerSet Intersection(IntegerSet s)
        {
            IntegerSet temp = new IntegerSet();
            for (int i = 0; i < arraySize; i++)
            {
                temp.set[i] = this.set[i] && s.set[i];
            }

            return temp;
        }

        /// <summary>
        /// Method inserts the integer k into this set
        /// </summary>
        /// <param name="k">integer k.</param>
        public void InsertElement(int k)
        {
            if (k >= 0 && k < arraySize)
                this.set[k] = true;
            else
                Console.WriteLine("Invalid input.\n");
        }

        /// <summary>
        /// Method deletes the integer k from this set
        /// </summary>
        /// <param name="k">integer k.</param>
        public void DeleteElement(int k)
        {
            if (k >= 0 && k < arraySize)
                this.set[k] = false;
            else
                Console.WriteLine("Invalid input.\n");
        }

        /// <summary>
        /// Method creates a list, separated by commas, of integers in this set
        /// </summary>
        /// <returns>A string <see cref="T:System.String"/> that lists elements 
        /// in <see cref="T:Lab1.IntegerSet"/>.</returns>
        public override string ToString()
        {
            string temp = "";
            bool foundFirstTrue = false;

            for (int i = 0; i < arraySize; i++)
            {
                if (this.set[i] && foundFirstTrue)
                    temp = temp + "," + Convert.ToString(i);
                
                if (this.set[i] && !foundFirstTrue)
                {
                    foundFirstTrue = true;
                    temp = temp + Convert.ToString(i);
                }
            }

            return temp;
        }

        /// <summary>
        /// Method determines if this set and set s share the same elements
        /// </summary>
        /// <returns><c>true</c>, if equal members, <c>false</c> 
        /// otherwise.</returns>
        /// <param name="s">S.</param>
        public bool IsEqualTo(IntegerSet s)
        {
            bool isEqual = true;

            int i = 0;
            while (isEqual && i < arraySize)
            {
                if (this.set[i] != s.set[i])
                    isEqual = false;
                i++;
            }
            return isEqual;
        }
    }
}