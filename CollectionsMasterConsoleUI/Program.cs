using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CollectionsMasterConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Follow the steps provided in the comments under each region.
            //Make the console formatted to display each section well
            //Utlilize the method stubs at the bottom for the methods you must create ⬇⬇⬇

            #region Arrays
            //TODO: Create an integer Array of size 50
            var bigArr = new int[50];

            //TODO: Create a method to populate the number array with 50 random numbers that are between 0 and 50

            bigArr = CreateBigArray(bigArr);

            //TODO: Print the first number of the array
            Console.WriteLine($"The first number of the random array is: {bigArr[0]}");
            
            //TODO: Print the last number of the array            
            Console.WriteLine($"The last is: {bigArr.Last()}");
            
            Console.WriteLine("All Numbers Original");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(bigArr);
            Console.WriteLine("-------------------");

            //TODO: Reverse the contents of the array and then print the array out to the console.
            //Try for 2 different ways
            /*  1) First way, using a custom method => Hint: Array._____(); 
                2) Second way, Create a custom method (scroll to bottom of page to find ⬇⬇⬇)
            */

            Console.WriteLine("All Numbers Reversed:");
            Console.WriteLine(string.Join(", ", bigArr.Reverse()));
            
            Console.WriteLine("---------REVERSE CUSTOM------------");

            ReverseArray(bigArr);

            Console.WriteLine("-------------------");

            //TODO: Create a method that will set numbers that are a multiple of 3 to zero then print to the console all numbers
            Console.WriteLine("Multiple of three = 0: ");

            threeToZero(bigArr);

            Console.WriteLine("-------------------");

            //TODO: Sort the array in order now
            /*      Hint: Array.____()      */
            Array.Sort(bigArr);
            Console.WriteLine(String.Join(", ", bigArr));
            
            Console.WriteLine("\n************End Arrays*************** \n");
            #endregion

            #region Lists
            Console.WriteLine("************Start Lists**************");

            /*   Set Up   */
            //TODO: Create an integer List
            List<int> intList = new List<int>();

            //TODO: Print the capacity of the list to the console
            Console.WriteLine($"The Capacity intially is: {intList.Capacity}");
            foreach (var item in intList)
            {
                Console.WriteLine(item);
            }

            //TODO: Populate the List with 50 random numbers between 0 and 50 you will need a method for this            
            intList = Populater(intList);
            foreach (var item in intList)
            {
                Console.WriteLine(item);
            }

            //TODO: Print the new capacity
            Console.WriteLine($"The new capacity is: {intList.Capacity}");

            Console.WriteLine("---------------------");

            //TODO: Create a method that prints if a user number is present in the list
            //Remember: What if the user types "abc" accident your app should handle that!
            Console.WriteLine("What number will you search for in the number list?");
            int userNum = 0;
            var userSuccess = int.TryParse(Console.ReadLine(), out userNum);
            if (userSuccess)
            {
                Console.WriteLine(NumberChecker(intList, userNum));
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.WriteLine("-------------------");

            Console.WriteLine("All Numbers:");
            //UNCOMMENT this method to print out your numbers from arrays or lists
            NumberPrinter(intList);
            Console.WriteLine("-------------------");


            //TODO: Create a method that will remove all odd numbers from the list then print results
            Console.WriteLine("Evens Only!!");
            intList = OddKiller(intList);
            
            Console.WriteLine("------------------");

            //TODO: Sort the list then print results
            Console.WriteLine("Sorted Evens!!");
            intList.Sort();
            Console.WriteLine(string.Join(", ", intList));
            
            Console.WriteLine("------------------");

            //TODO: Convert the list to an array and store that into a variable
            int[] intArray = intList.ToArray();
            
            //TODO: Clear the list
            intList.Clear();

            #endregion
        }

        private static void threeToZero(int[] numbers)
        {
            var newArray = new int[numbers.Length];
            for(int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 3 != 0)
                {
                    newArray[i] = numbers[i];
                }
                else
                {
                    newArray[i] = 0;
                }
            }
            Console.WriteLine(string.Join(", ", newArray));
        }


        private static List<int> OddKiller(List<int> numberList)
        {
            var evenList = (List<int>)numberList.Where(number => number % 2 == 0).ToList();
            Console.WriteLine(string.Join(", ", evenList));
            return evenList;
        }

        private static string NumberChecker(List<int> numberList, int searchNumber)
        {
            foreach (var num in numberList)
            {
                if (num == searchNumber)
                {
                    return "Your number is in the list!";
                }
            }
            return "Your number is not in the list...";
        }

        private static List<int> Populater(List<int> numberList)
        {
            Random rng = new Random();
            for (int i = 0; i < 50; i++)
            {
                numberList.Add(rng.Next(51));
            }
            return numberList;
        }

        private static int[] CreateBigArray(int[] bigArr)
        {
            var rnd = new Random(); 
            
            for (int i = 0; i < bigArr.Length; i++)
            {
                bigArr[i] = rnd.Next(51);
            }

            return bigArr;
        }
        private static void ReverseArray(int[] array)
        {
            for(int i = array.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(array[i]);
            }
        }

        /// <summary>
        /// Generic print method will iterate over any collection that implements IEnumerable<T>
        /// </summary>
        /// <typeparam name="T"> Must conform to IEnumerable</typeparam>
        /// <param name="collection"></param>
        private static void NumberPrinter<T>(T collection) where T : IEnumerable<int>
        {
            //STAY OUT DO NOT MODIFY!!
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
