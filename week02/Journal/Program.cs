using System;

/*
Creativity Exceeded Requirements

This journal program exceeds the core requirements by allowing users
to record their mood with each journal entry. The mood is saved to the
journal file, displayed whenever journal entries are viewed, and
restored when the journal is loaded from a file. This provides
additional context for each journal entry and helps users reflect on
their emotional well-being over time.
*/

class Program
{
    static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator generator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("===== Journal Menu =====");
            Console.WriteLine("1. Write a New Entry");
            Console.WriteLine("2. Display Journal");
            Console.WriteLine("3. Save Journal");
            Console.WriteLine("4. Load Journal");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine();

                    string prompt = generator.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");

                    Console.Write("Your response: ");
                    string response = Console.ReadLine() ?? "";

                    Console.Write("How are you feeling today? ");
                    string mood = Console.ReadLine() ?? "";

                    Entry newEntry = new Entry(
                        DateTime.Now.ToShortDateString(),
                        prompt,
                        response,
                        mood);

                    myJournal.AddEntry(newEntry);

                    Console.WriteLine("Journal entry added successfully.");
                    break;

                case "2":
                    Console.WriteLine();
                    myJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter filename: ");
                    string saveFile = Console.ReadLine() ?? "";

                    myJournal.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter filename: ");
                    string loadFile = Console.ReadLine() ?? "";

                    myJournal.LoadFromFile(loadFile);
                    break;

                case "5":
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }
}