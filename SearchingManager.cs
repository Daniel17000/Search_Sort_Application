using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Sort_Application
{
    internal class SearchingManager
    {
        public void PerformSearch(string[] lines)
        {
            // Lets the user select a searching algorithm
            Console.WriteLine("\nSelect search algorithm:");
            Console.WriteLine("1. Binary Search");
            Console.WriteLine("2. Linear Search");
            Console.Write("Enter the number of your choice (1-2): ");

            int searchChoice;

            //Validation for user input
            while (!int.TryParse(Console.ReadLine(), out searchChoice) || searchChoice < 1 || searchChoice > 2)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Enter the number of your choice (1-2): ");
            }

            if (searchChoice == 1)
            {
                // Perform binary search
                Console.Write("\nEnter a value to search for: ");
                if (int.TryParse(Console.ReadLine(), out int searchValue))
                {
                    int searchSteps;
                    int index = BinarySearch(lines, searchValue, out searchSteps);
                    if (index != -1 && int.Parse(lines[index]) == searchValue)
                    {
                        Console.WriteLine($"Value {searchValue} found at position {index}.");
                    }
                    else
                    {
                        // If value isnt found then this will find the nearest value
                        int nearestIndex = BinarySearch(lines, searchValue, out searchSteps);
                        if (nearestIndex != -1)
                        {
                            int nearestValue = int.Parse(lines[nearestIndex]);
                            Console.WriteLine($"Value {searchValue} not found. Nearest value {nearestValue} found at position {nearestIndex}.");
                        }
                        else
                        {
                            Console.WriteLine($"Value {searchValue} not found. Nearest value not found.");
                        }
                    }
                    Console.WriteLine($"Search steps: {searchSteps}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer value.");
                }
            }
            else
            {
                // Perform linear search
                Console.Write("\nEnter a value to search for: ");
                if (int.TryParse(Console.ReadLine(), out int searchValue))
                {
                    int searchSteps;
                    // Calls the linear search method 
                    int index = LinearSearch(lines, searchValue, out searchSteps);
                    if (index != -1 && int.Parse(lines[index]) == searchValue)
                    {
                        Console.WriteLine($"Value {searchValue} found at position {index}.");
                    }
                    else
                    {
                        // If the value isnt found then this will once again find the nearest value
                        int nearestIndex = LinearSearch(lines, searchValue, out searchSteps);
                        if (nearestIndex != -1)
                        {
                            int nearestValue = int.Parse(lines[nearestIndex]);
                            Console.WriteLine($"Value {searchValue} not found. Nearest value {nearestValue} found at position {nearestIndex}.");
                        }
                        else
                        {
                            Console.WriteLine($"Value {searchValue} not found. Nearest value not found.");
                        }
                    }
                    Console.WriteLine($"Search steps: {searchSteps}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer value.");
                }
            }
        }

        // Binary search algorithm being used
        private int BinarySearch(string[] array, int value, out int steps)
        {
            steps = 0;
            int left = 0;
            int right = array.Length - 1;
            int nearestIndex = -1;
            int minDifference = int.MaxValue;

            // The search iteration 
            while (left <= right)
            {
                steps++;
                int mid = left + (right - left) / 2;
                int midValue = int.Parse(array[mid]);
                if (midValue == value)
                    return mid;
                else if (midValue < value)
                    left = mid + 1;
                else
                    right = mid - 1;

                // Update the nearest value found so far
                int difference = Math.Abs(midValue - value);
                if (difference < minDifference)
                {
                    minDifference = difference;
                    nearestIndex = mid;
                }
            }
            return nearestIndex;
        }


        // Linear search implementation being done
        private int LinearSearch(string[] array, int value, out int steps)
        {
            steps = 0;
            int nearestIndex = -1;
            int minDifference = int.MaxValue;

            // The iteration
            for (int i = 0; i < array.Length; i++)
            {
                steps++;
                int currentValue = int.Parse(array[i]);
                if (currentValue == value)
                    return i;

                // Once again updating the nearest value found
                int difference = Math.Abs(currentValue - value);
                if (difference < minDifference)
                {
                    minDifference = difference;
                    nearestIndex = i;
                }
            }

            return nearestIndex;
        }
    }
}
