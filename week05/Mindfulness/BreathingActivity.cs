using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Clear();

            Console.WriteLine("Breathe in...");
            ShowCountdown(4);

            Console.WriteLine();

            if (DateTime.Now >= endTime)
                break;

            Console.WriteLine("Breathe out...");
            ShowCountdown(4);

            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}