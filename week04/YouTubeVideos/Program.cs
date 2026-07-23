using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        // Video 1
        Video video1 = new Video(
            "Learning C# for Beginners",
            "Code Academy",
            720);

        video1.AddComment(new Comment("James", "Excellent explanation!"));
        video1.AddComment(new Comment("Sarah", "Very easy to understand."));
        video1.AddComment(new Comment("David", "Thanks for sharing."));
        video1.AddComment(new Comment("Grace", "Please upload Part 2."));

        videos.Add(video1);

        // Video 2
        Video video2 = new Video(
            "Healthy Living Tips",
            "Wellness Hub",
            540);

        video2.AddComment(new Comment("Mary", "Very informative."));
        video2.AddComment(new Comment("John", "I learned something new."));
        video2.AddComment(new Comment("Paul", "Great presentation."));
        video2.AddComment(new Comment("Linda", "Helpful advice."));

        videos.Add(video2);

        // Video 3
        Video video3 = new Video(
            "Top 10 Travel Destinations",
            "Travel World",
            960);

        video3.AddComment(new Comment("Samuel", "Amazing places!"));
        video3.AddComment(new Comment("Esther", "I want to visit Japan."));
        video3.AddComment(new Comment("Michael", "Beautiful video."));
        video3.AddComment(new Comment("Joy", "Fantastic editing."));

        videos.Add(video3);

        // Video 4
        Video video4 = new Video(
            "Understanding Object-Oriented Programming",
            "Tech School",
            830);

        video4.AddComment(new Comment("Daniel", "This really helped."));
        video4.AddComment(new Comment("Rachel", "Excellent examples."));
        video4.AddComment(new Comment("Peter", "Very detailed lesson."));
        video4.AddComment(new Comment("Faith", "Best tutorial I've watched."));

        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");

            Console.WriteLine("\nComment List:");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"{comment.GetName()}: {comment.GetText()}");
            }

            Console.WriteLine();
        }
    }
}