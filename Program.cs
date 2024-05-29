using System;
using System.IO;


namespace Search_Sort_Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating instances/objects of FileManager, SortingManager, and SearchingManager
            FileManager filemanager = new FileManager();
            SortingManager sortingmanager = new SortingManager();
            SearchingManager searchingmanager = new SearchingManager();

            // Get the files from the FileManager
            string[] selectedFile = filemanager.GetSelectedFiles();

            // Processing each file 
            foreach (var selectedFilePath in selectedFile)
            {
                string[] lines = File.ReadAllLines(selectedFilePath);   // Reading all the lines from the file
                lines = sortingmanager.SortLines(lines);        // Sorts the lines using the SortingManager
                sortingmanager.DisplaySortedContent(lines);     // Displays the sorted items
                searchingmanager.PerformSearch(lines);          // Will perform the searching on the items
            }

            // Display message for the users
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
