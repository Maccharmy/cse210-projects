using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (choice == "1")
        {
            _goals.Add(
                new SimpleGoal(name, description, points)
            );
        }
        else if (choice == "2")
        {
            _goals.Add(
                new EternalGoal(name, description, points)
            );
        }
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for completing the goal? ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(
                new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus
                )
            );
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }

        Console.WriteLine("Goal created successfully!");
    }

    public void ListGoals()
    {
        Console.WriteLine("\nYour Goals");
        Console.WriteLine("----------------------------------------");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals to record.");
            return;
        }

        ListGoals();

        Console.Write("\nWhich goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        if (choice >= 1 && choice <= _goals.Count)
        {
            Goal selectedGoal = _goals[choice - 1];

            int pointsEarned = selectedGoal.RecordEvent();

            if (pointsEarned > 0)
            {
                _score += pointsEarned;

                Console.WriteLine(
                    $"\nCongratulations! You earned {pointsEarned} points."
                );

                Console.WriteLine($"Your total score is now {_score}.");

                if (selectedGoal is ChecklistGoal &&
                    selectedGoal.IsComplete())
                {
                    Console.WriteLine(
                        "Congratulations! You completed your checklist goal!"
                    );
                }
            }
            else
            {
                Console.WriteLine(
                    "\nThis goal has already been completed."
                );
            }
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"\nCurrent Score: {_score}");
        Console.WriteLine($"Level: {GetLevel()}");
    }

    public string GetLevel()
    {
        if (_score >= 5000)
        {
            return "Eternal Champion";
        }
        else if (_score >= 2000)
        {
            return "Dedicated Servant";
        }
        else if (_score >= 1000)
        {
            return "Faithful Disciple";
        }
        else if (_score >= 500)
        {
            return "Goal Seeker";
        }
        else
        {
            return "Beginner";
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(
                    goal.GetStringRepresentation()
                );
            }
        }

        Console.WriteLine(
            $"\nGoals and score successfully saved to {filename}."
        );
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine(
                "\nNo saved goals file was found."
            );

            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            Console.WriteLine("The save file is empty.");
            return;
        }

        _score = int.Parse(lines[0]);

        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');

            if (parts[0] == "SimpleGoal")
            {
                SimpleGoal goal = new SimpleGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3])
                );

                bool isComplete = bool.Parse(parts[4]);

                if (isComplete)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
            else if (parts[0] == "EternalGoal")
            {
                EternalGoal goal = new EternalGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3])
                );

                _goals.Add(goal);
            }
            else if (parts[0] == "ChecklistGoal")
            {
                ChecklistGoal goal = new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5])
                );

                int amountCompleted = int.Parse(parts[6]);

                for (int j = 0; j < amountCompleted; j++)
                {
                    goal.RecordEvent();
                }

                _goals.Add(goal);
            }
        }

        Console.WriteLine(
            $"\nGoals and score successfully loaded from {filename}."
        );
    }
}