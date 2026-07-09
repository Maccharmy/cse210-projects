using System;

public class Entry
{
    public string _date;
    public string _prompt;
    public string _response;
    public string _mood; 

    public Entry(string date, string prompt, string response, string mood = "")
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} | Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        if (!string.IsNullOrEmpty(_mood))
        {
            Console.WriteLine($"Mood: {_mood}");
        }
        Console.WriteLine();
    }

    public string ToFileFormat()
    {
        return $"{_date}|{_prompt}|{_response}|{_mood}";
    }

    public static Entry FromFileFormat(string line)
    {
        string[] parts = line.Split('|');
        return new Entry(parts[0], parts[1], parts[2], parts.Length > 3 ? parts[3] : "");
    }
}
