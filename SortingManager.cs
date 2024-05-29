using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Search_Sort_Application
{
    internal class SortingManager
    {
        private int steps; // Variable to count steps

        // Method to reset the step count
        private void ResetSteps()
        {
            steps = 0;
        }

        // Method to get the step count
        public int GetStepCount()
        {
            return steps;
        }

        public string[] SortLines(string[] lines)
        {
            // Reset step count before sorting
            ResetSteps();

            // Let the user select a sorting algorithm
            Console.WriteLine(); // Empty line
            Console.WriteLine("Select sorting algorithm:");
            Console.WriteLine("1. Merge Sort");
            Console.WriteLine("2. Bubble Sort");
            Console.WriteLine("3. Quick Sort");
            Console.WriteLine("4. Insertion Sort");
            Console.Write("Enter the number of the sorting algorithm: ");

            int sortAlgorithm;

            // Validation for user input
            while (!int.TryParse(Console.ReadLine(), out sortAlgorithm) || sortAlgorithm < 1 || sortAlgorithm > 4)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Enter the number of the sorting algorithm: ");
            }

            Console.WriteLine();    // Empty line
            Console.WriteLine("Select sorting order:");
            Console.WriteLine("1. Ascending");
            Console.WriteLine("2. Descending");
            Console.Write("Enter the number of your choice (1-2): ");

            int sortOrder;
            while (!int.TryParse(Console.ReadLine(), out sortOrder) || sortOrder < 1 || sortOrder > 2)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Enter the number of your choice (1-2): ");
            }

            bool ascending = (sortOrder == 1);

            // Based on the selected algorithm it will start sorting
            switch (sortAlgorithm)
            {
                case 1:
                    MergeSort(lines);
                    break;
                case 2:
                    BubbleSort(lines);
                    break;
                case 3:
                    QuickSort(lines, 0, lines.Length - 1);
                    break;
                case 4:
                    InsertionSort(lines);
                    break;
            }

            // If the descending order is selected the array is reversed
            if (!ascending)
            {
                Array.Reverse(lines);
            }

            return lines;
        }

        // Method to display the sorted content
        public void DisplaySortedContent(string[] sortedLines)
        {
            Console.WriteLine("\nSorted content:");
            foreach (var line in sortedLines)
            {
                Console.WriteLine(line);
            }

            // Display the step count
            Console.WriteLine($"\nSteps taken for sorting: {GetStepCount()}");

            // Analyze every 10th or 50th value based on the file size
            if (sortedLines.Length == 256) // If file size is 256 lines
            {
                Console.WriteLine("\nEvery 10th value of the sorted content:");
                for (int i = 9; i < sortedLines.Length; i += 10)
                {
                    Console.WriteLine(sortedLines[i]);
                }
            }
            else if (sortedLines.Length == 2048) // If file size is 2048 lines
            {
                Console.WriteLine("\nEvery 50th value of the sorted content:");
                for (int i = 49; i < sortedLines.Length; i += 50)
                {
                    Console.WriteLine(sortedLines[i]);
                }
            }
            else // File size is neither 256 nor 2048 lines
            {
                Console.WriteLine("\nFile size is neither 256 nor 2048 lines.");
            }
        }

        // Merge sort algorithm used
        private void MergeSort(string[] array)
        {
            MergeSort(array, 0, array.Length - 1);
        }

        private void MergeSort(string[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(array, left, middle);
                MergeSort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        // The merge phase of merge sort being implemented
        private void Merge(string[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            // Creates temporary arrays
            string[] L = new string[n1];
            string[] R = new string[n2];

            // Copy data to temporary arrays
            Array.Copy(array, left, L, 0, n1);
            Array.Copy(array, middle + 1, R, 0, n2);

            // Merge those arrays
            int i = 0, j = 0;
            int k = left;
            while (i < n1 && j < n2)
            {
                if (int.Parse(L[i]) <= int.Parse(R[j]))
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = R[j];
                    j++;
                }
                k++;

                // Increment step count
                steps++;
            }

            while (i < n1)
            {
                array[k] = L[i];
                i++;
                k++;

                // Increment step count
                steps++;
            }

            while (j < n2)
            {
                array[k] = R[j];
                j++;
                k++;

                // Increment step count
                steps++;
            }
        }

        // Bubble sort algorithm used
        private void BubbleSort(string[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (int.Parse(array[j]) > int.Parse(array[j + 1]))
                    {
                        // Swaps the elements
                        string temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;

                        // Increment step count
                        steps++;
                    }
                }
            }
        }

        // Quick sort implemented
        private void QuickSort(string[] array, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(array, low, high);
                QuickSort(array, low, pi - 1);
                QuickSort(array, pi + 1, high);
            }
        }

        // Partition step of quick sort
        private int Partition(string[] array, int low, int high)
        {
            string pivot = array[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (int.Parse(array[j]) < int.Parse(pivot))
                {
                    i++;
                    string temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;

                    // Increment step count
                    steps++;
                }
            }

            // Swaps elements
            string temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;

            // Increment step count
            steps++;

            return i + 1;
        }

        // Insertion sort algorithm used
        private void InsertionSort(string[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                string key = array[i];
                int j = i - 1;

                // Moving the elements 
                while (j >= 0 && int.Parse(array[j]) > int.Parse(key))
                {
                    array[j + 1] = array[j];
                    j = j - 1;

                    // Increment step count
                    steps++;
                }

                // Insert the key into the correct position
                array[j + 1] = key;

                // Increment step count
                steps++;
            }
        }
    }
}

