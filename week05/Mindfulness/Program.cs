using System;

/*
    Creativity Exceeded Requirements

    This program exceeds the core requirements by keeping a history
    of every activity completed during the current session. Users can
    choose the "View Activity History" option from the main menu to
    review all completed mindfulness activities along with the date,
    time, and duration.
*/

class Program
{
    static void Main(string[] args)
    {
        ActivityLog log = new ActivityLog();

        string choice = "";

        while (choice != "5")
        {
            Console.Clear();

            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. View Activity History");
            Console.WriteLine("5. Quit");
            Console.WriteLine();

            Console.Write("Select a choice: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    log.AddActivity("Breathing Activity", breathing.GetDuration());
                    break;

                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    log.AddActivity("Reflection Activity", reflection.GetDuration());
                    break;

                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    log.AddActivity("Listing Activity", listing.GetDuration());
                    break;

                case "4":
                    log.DisplayHistory();
                    break;

                case "5":
                    Console.WriteLine();
                    Console.WriteLine("Thank you for using the Mindfulness Program!");
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}