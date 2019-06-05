using System;
using System.Net;
using System.Collections.Generic;

public class photoDisplay
{
    //Default Case assumes invalid input
    public string displayResult = "Your input was not a number. Please try again.";
	public photoDisplay(string userInput)
	{
        //URL setup for grabbing photos from a specific album
        string targetURL = "https://jsonplaceholder.typicode.com/photos?albumId=";
        int albumSelection = 0;//placeholder to be reassigned

        //Exception Handling on User Input - prevent input of non Int values
        bool successParse = false;
        successParse = int.TryParse(userInput, out albumSelection);
        if (successParse)
        {
            // Add album selection to the URL
            targetURL += albumSelection;
        }
        
        //Download the relevant data
        string targetJSON = new WebClient().DownloadString(targetURL);
        //Check for empty album with valid input
        if (targetJSON.Equals("[]") || !successParse)
        {
            if (successParse)
            {
                displayResult = "There are no photos in that album.";
            }
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

            //setup the displayed result
            displayResult = "";
            foreach (string s in idAndTitle)
            {
                displayResult += s + "\n";
            }
        }
    }
}
