using System;
using System.Collections.Generic;

public class ActivityLog
{
    private List<string> _history = new List<string>();

    public void AddActivity(string activityName, int duration)
    {
        _history.Add($"{DateTime.Now:g} - {activityName} ({duration} seconds)");
    }

    public void DisplayHistory()
    {
        Console.Clear();
        Console.WriteLine("Activity History");
        Console.WriteLine("-------------------------");

        if (_history.Count == 0)
        {
            Console.WriteLine("No activities have been completed yet.");
        }
        else
        {
            foreach (string activity in _history)
            {
                Console.WriteLine(activity);
            }
        }

        Console.WriteLine();
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}