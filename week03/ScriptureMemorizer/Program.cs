using System;
using System.Collections.Generic;

// Creativity and Exceeding Requirements:
// 1. The program stores multiple scriptures in a library.
// 2. A random scripture is selected each time the program runs.
// 3. The program only hides words that are not already hidden.
// These enhancements make scripture memorization more effective and exceed
// the core assignment requirements. Thank you

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life."
            ),

            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths."
            ),

            new Scripture(
                new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God."
            )
        };

        Random random = new Random();
        Scripture scripture = scriptures[random.Next(scriptures.Count)];

        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            Console.Write("Press Enter to continue or type 'quit': ");

            string input = Console.ReadLine();

            // Trim handles accidental spaces before or after "quit"
            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }

        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());

        Console.WriteLine();
        Console.WriteLine("Program finished.");
    }
}