using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // Stores all journal entries
    private List<Entry> _entries = new List<Entry>();

    // Adds a journal entry
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    // Displays all journal entries
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is currently empty.");
            return;
        }

        Console.WriteLine();

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Saves all entries to a file
    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.ToFileFormat());
                }
            }

            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    // Loads entries from a file
    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _entries.Clear();

            string[] lines = File.ReadAllLines(filename);

            foreach (string line in lines)
            {
                _entries.Add(Entry.FromFileFormat(line));
            }

            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}