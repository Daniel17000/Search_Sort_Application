using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Sort_Application
{
    internal class FileManager
    {

        public string[] GetSelectedFiles()
        {
            Console.WriteLine("Welcome, this is an application for the analysis of Network Traffic data.");

            // Asks the user if they would like to merge files before carrying on 
            Console.WriteLine("\nDo you wish to merge files before proceeding?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.Write("Enter the number of your choice: ");

            int mergeChoice;
            // Validation for user input
            while (!int.TryParse(Console.ReadLine(), out mergeChoice) || mergeChoice < 1 || mergeChoice > 2)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                Console.Write("Enter the number of your choice (1-2): ");
            }

            string[] selectedFiles;
            if (mergeChoice == 1) // Merge files
            {
                selectedFiles = MergeFiles();
            }
            else // Use individual files
            {
                selectedFiles = SelectFiles();
            }

            return selectedFiles;
        }

        // Method to merge the chosen files
        private string[] MergeFiles()
        {
            // Defines the folder path where the files are stored
            string folderPath = "../../../../Assignment txt files";

            Console.WriteLine("Select two files to merge:");

            // Gets all the files within the folder (text files espically)
            string[] fileEntries = Directory.GetFiles(folderPath, "*.txt");

            // Displays the file names with numbers for the user to select from
            for (int i = 0; i < fileEntries.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(fileEntries[i])}");
            }

            int firstFileIndex, secondFileIndex;
            do
            {
                Console.Write("Enter the number of the first file (1-6): ");
            } while (!int.TryParse(Console.ReadLine(), out firstFileIndex) || firstFileIndex < 1 || firstFileIndex > 6);

            do
            {
                Console.Write("Enter the number of the second file (1-6, different from the first): ");
            } while (!int.TryParse(Console.ReadLine(), out secondFileIndex) || secondFileIndex < 1 || secondFileIndex > 6 || secondFileIndex == firstFileIndex);

            // creates an array containing paths of the selected files
            string[] selectedFiles = new string[] { fileEntries[firstFileIndex - 1], fileEntries[secondFileIndex - 1] };

            // This would merge the selected files and save them to the file path that would be shown in the terminal
            string mergedFilePath = MergeFiles(selectedFiles[0], selectedFiles[1]);
            Console.WriteLine($"Files merged successfully. Merged file saved at: {mergedFilePath}");

            return new string[] { mergedFilePath };
        }

        // Method to select individual files
        private string[] SelectFiles()
        {
            string folderPath = "../../../../Assignment txt files";

            Console.WriteLine();    //Empty line
            Console.WriteLine("Select a file to sort:");
            string[] fileEntries = Directory.GetFiles(folderPath, "*.txt");
            for (int i = 0; i < fileEntries.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(fileEntries[i])}");
            }

            int selectedFileIndex;
            do
            {
                Console.Write("Enter the number of the file (1-6): ");
            } while (!int.TryParse(Console.ReadLine(), out selectedFileIndex) || selectedFileIndex < 1 || selectedFileIndex > 6);

            return new string[] { fileEntries[selectedFileIndex - 1] };
        }

        // Method for merging the two files
        private string MergeFiles(string firstFilePath, string secondFilePath)
        {
            string mergedFilePath = "../../../../MergedFile.txt";

            // Create or overwrites the merged file
            using (StreamWriter writer = new StreamWriter(mergedFilePath))
            {
                // Reads and wreite the contents of the first file
                string[] firstFileLines = File.ReadAllLines(firstFilePath);
                foreach (string line in firstFileLines)
                {
                    writer.WriteLine(line);
                }
                // Reads and writes the contents of the Second File
                string[] secondFileLines = File.ReadAllLines(secondFilePath);
                foreach (string line in secondFileLines)
                {
                    writer.WriteLine(line);
                }
            }

            // Returns the file path of the merged file
            return mergedFilePath;
        }
    }
}
