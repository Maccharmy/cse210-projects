using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int input;
        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        if (numbers.Count > 0)
        {
            int sum = numbers.Sum();
            double average = numbers.Average();
            int max = numbers.Max();

            Console.WriteLine($"The sum is: {sum}");
            Console.WriteLine($"The average is: {average:F2}"); 
            Console.WriteLine($"The largest number is: {max}");

            // Stretch challenge: smallest positive number
            int smallestPositive = numbers.Where(n => n > 0).DefaultIfEmpty(int.MaxValue).Min();
            if (smallestPositive != int.MaxValue)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }

            // Stretch challenge: sorted list
            numbers.Sort();
            Console.WriteLine("The sorted list is:");
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered. Nothing to calculate.");
        }
    }
}
