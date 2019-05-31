using System;
using System.Net;
using System.Collections.Generic;

namespace Photo_Album_Display_LT
{
    class Program
    {
        static void Main(string[] args)
        {
            string targetURL = "https://jsonplaceholder.typicode.com/photos?albumId=";//URL setup for grabbing photos from a specific album
            Console.Write("Please enter an album number to display relevant photo IDs and titles: ");
            string userInput = Console.ReadLine();
            int albumSelection = 0;//placeholder to be reassigned

            bool successParse = false;//Exception Handling on User Input - prevent input of non Int values
            while (successParse.Equals(false))
            {
                successParse = int.TryParse(userInput, out albumSelection);
                if (successParse)
                {
                    targetURL += albumSelection;// Add album selection to the URL
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

            string targetJSON = new WebClient().DownloadString(targetURL); //Download the relevant data

            List<string> idAndTitle = new List<string>();
            
            String[] individualFields = targetJSON.Split(','); //Split the individual fields apart
            string result = "";
            foreach(string t in individualFields)//Toss out irrelevant information
            {
              if(t.Contains("\"id\""))
              {
                result += t;
              }
              if(t.Contains("\"title\""))
              {
                result += t;
                result += "\n";
              }
            }
            idAndTitle.Add(result);
            
            Console.WriteLine("OUTPUT:");
            foreach(string s in idAndTitle)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
