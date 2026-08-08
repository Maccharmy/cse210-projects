using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        /*
         * CREATIVITY AND EXCEEDING REQUIREMENTS:
         *
         * In addition to the required Eternal Quest functionality,
         * I added a level system based on the user's total score.
         * As users earn more points, they receive different titles:
         *
         * 0 - 499     : Beginner
         * 500 - 999   : Goal Seeker
         * 1000 - 1999 : Faithful Disciple
         * 2000 - 4999 : Dedicated Servant
         * 5000+       : Eternal Champion
         *
         * This provides additional gamification and motivation
         * beyond the core requirements of the assignment.
         */

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine("           ETERNAL QUEST");
            Console.WriteLine("========================================");

            manager.DisplayScore();

            Console.WriteLine();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("\nSelect a choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;

                case "2":
                    manager.ListGoals();
                    break;

                case "3":
                    manager.SaveGoals("goals.txt");
                    break;

                case "4":
                    manager.LoadGoals("goals.txt");
                    break;

                case "5":
                    manager.RecordEvent();
                    break;

                case "6":
                    running = false;
                    Console.WriteLine(
                        "\nThank you for using Eternal Quest!"
                    );
                    break;

                default:
                    Console.WriteLine(
                        "\nInvalid choice. Please select 1-6."
                    );
                    break;
            }
        }
    }
}