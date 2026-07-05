using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        int percent = int.Parse(Console.ReadLine());

        string letter;

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        string sign = "";
        int lastDigit = percent % 10;

        if (letter != "F" && letter != "A") 
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && percent < 93) 
        {
            if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is {letter}{sign}.");

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course. keep up the good work!");
        }
        else
        {
            Console.WriteLine("Do not give up!Keep working hard—you’ll do better next time!");
        }
    }
}
