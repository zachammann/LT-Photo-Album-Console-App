using System;
using System.Net;
using System.Collections.Generic;

namespace Photo_Album_Display_LT
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            while (true)
            {
                //URL setup for grabbing photos from a specific album
                string targetURL = "https://jsonplaceholder.typicode.com/photos?albumId=";
                Console.Write("Please enter an album number to display relevant photo IDs and titles\nor enter \"q\" to quit: ");
                userInput = Console.ReadLine();
                if(userInput.Equals("q") || userInput.ToLower().Equals("q"))
                {
                    System.Environment.Exit(1);
                }
                int albumSelection = 0;//placeholder to be reassigned

                //Exception Handling on User Input - prevent input of non Int values
                bool successParse = false;
                while (successParse.Equals(false))
                {
                    successParse = int.TryParse(userInput, out albumSelection);
                    if (successParse)
                    {
                        // Add album selection to the URL
                        targetURL += albumSelection;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.Write("Your input was not a number. Please try again: ");
                        userInput = Console.ReadLine();
                    }
                }
                Console.WriteLine("Ready to display IDs and Titles from Album " + albumSelection + ". Please press any key.");
                Console.ReadKey();

                //Download the relevant data
                string targetJSON = new WebClient().DownloadString(targetURL);
                //Check for empty album
                if (targetJSON.Equals("[]"))
                {
                    Console.WriteLine("There are no photos in that album.");
                }
                else
                {
                    List<string> idAndTitle = new List<string>();

                    //Split the individual fields apart
                    String[] individualFields = targetJSON.Split(',');
                    string result = "";
                    //Toss out irrelevant information
                    foreach (string t in individualFields)
                    {
                        if (t.Contains("\"id\""))
                        {
                            result += t;
                        }
                        if (t.Contains("\"title\""))
                        {
                            result += t;
                            result += "\n";
                        }
                    }
                    idAndTitle.Add(result);

                    Console.WriteLine("OUTPUT:");
                    foreach (string s in idAndTitle)
                    {
                        Console.WriteLine(s);
                    }
                }
                Console.ReadKey();
            }
        }
    }
}
