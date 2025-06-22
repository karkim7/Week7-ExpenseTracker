using System;
using System.Collections.Generic;

class Expense
{
    public string Description { get; set; }
    public double Amount { get; set; }

    public Expense(string description, double amount)
    {
        Description = description;
        Amount = amount;
    }
}

class ExpenseTracker
{
    static void Main()
    {
        List<Expense> expenses = new List<Expense>();
        bool running = true;

        Console.WriteLine("=== Welcome to Simple Expense Tracker ===");

        while (running)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. View Total");
            Console.WriteLine("4. Exit");
            Console.Write("Your choice: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter description: ");
                    string desc = Console.ReadLine();

                    Console.Write("Enter amount: $");
                    double amount;
                    while (!double.TryParse(Console.ReadLine(), out amount) || amount < 0)
                    {
                        Console.Write("Invalid amount. Try again: $");
                    }

                    expenses.Add(new Expense(desc, amount));
                    Console.WriteLine("Expense added!");
                    break;

                case "2":
                    Console.WriteLine("\nYour Expenses:");
                    if (expenses.Count == 0)
                    {
                        Console.WriteLine("No expenses recorded.");
                    }
                    else
                    {
                        foreach (var e in expenses)
                        {
                            Console.WriteLine($"- {e.Description}: ${e.Amount:F2}");
                        }
                    }
                    break;

                case "3":
                    double total = 0;
                    foreach (var e in expenses)
                    {
                        total += e.Amount;
                    }
                    Console.WriteLine($"Total Spent: ${total:F2}");
                    break;

                case "4":
                    running = false;
                    Console.WriteLine("Exiting... Thank you!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
