using System;

namespace MyQuizApp;

// Entry point for the mini quiz project.
// Add more classes (Question, Player, Score, etc.) in this same folder
// using `namespace MyQuizApp;` and they will all share this namespace.
internal class Quiz
{
    private Question[] _questions;
    private int _score;

    public Quiz(Question[] questions)
    {
        _questions = questions;
        _score = 0;
    }



    public void StartQuiz()
    {
        Console.WriteLine("Welcome to the Quiz!");
        int questionNumber = 1; // to display question numbers;

        foreach (Question item in _questions)
        {
            Console.WriteLine($"Question {questionNumber++}:");
            DisplayQuestion(item);
            int userChoice = GetUserChoice();
            if (item.IsCorrectAnswer(userChoice))
            {
                Console.WriteLine("Correct!");
                _score++;
            }
            else
            {
                Console.WriteLine($"Wrong! The correct answer was : {item.Answers[item.CorrectAnswerIndex]}");
            }

        }
        DisplayResults();
    }

    private void DisplayResults()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔══════════════════════════════════╗");
        Console.WriteLine("║             Results              ║");
        Console.WriteLine("╚══════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine($"Quiz finished. Your score is: {_score} out of {_questions.Length}");

        double percentage = (double)_score / _questions.Length;

        if (percentage >= 0.8)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Excelent Work!");
        }
        else if (percentage >= 0.5)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Good effort!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Keep practicing!");
        }
    }

    private void DisplayQuestion(Question question)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔══════════════════════════════════╗");
        Console.WriteLine("║             Question             ║");
        Console.WriteLine("╚══════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine(question.QuestionText);

        for (int i = 0; i < question.Answers.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  ");
            Console.Write(i + 1);
            Console.ResetColor(); // Reset foregroun text color 
            Console.WriteLine($". {question.Answers[i]}");
        }

    }

    private int GetUserChoice()
    {
        string? input = Console.ReadLine();
        int choice = 0;
        while (!int.TryParse(input, out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid choice. PLease enter a number between 1 and 4: ");
            input = Console.ReadLine();
        }

        return choice - 1; // adjust to 0-indexed array

    }
}
