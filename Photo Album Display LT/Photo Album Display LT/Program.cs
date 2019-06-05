using System;

namespace Photo_Album_Display_LT
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";
            while (true)
            {
                Console.Write("Please enter an album number to display relevant photo IDs and titles\nor enter \"q\" to quit: ");
                userInput = Console.ReadLine();
                if(userInput.Equals("q") || userInput.ToLower().Equals("q"))
                {
                    System.Environment.Exit(1);
                }
                else
                {
                    photoDisplay albumQuery = new photoDisplay(userInput);
                    Console.WriteLine(albumQuery.displayResult);
                }                
            }
        }
    }
}
