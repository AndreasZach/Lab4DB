﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4DB
{
    public class Controller<T>
    {
        // Set your Azure connection details here.
        protected static string uri = @"https://localhost:8081";
        protected static string primaryKey = @"C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";

        protected OrdersDbContext orderContext = new OrdersDbContext(
            uri,
            primaryKey,
            "OrdersDB");

        protected ConsoleView view = new ConsoleView();

        protected virtual T Model { get; set; }

        protected virtual List<T> ModelList { get; set; }

        protected string UserInputHandlerString(int? maxVal = null)
        {
            string input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input) || input.Length < 1)
            {
                PrintError("Entry must be at least one character long.");
                return null;
            }
            if (input.Length > maxVal)
            {
                PrintError($"Entry cannot be longer than {maxVal} characters.");
                return null;
            }

            return input;
        }

        protected int UserInputHandlerInt(int maxVal, int minVal = 1)
        {
            int input;
            if (!Int32.TryParse(Console.ReadKey(true).KeyChar.ToString(), out input))
            {
                PrintError("Invalid input. Only integers are supported for this entry.\nMake sure Numlock is enabled if you used Numpad to enter a value.");
                return -1;
            }
            if (input < minVal || input > maxVal)
            {
                PrintError($"Entry can only be between 1 and {maxVal}");
                return -1;
            }
            return input;
        }

        protected void CommitDbChange()
        {
            orderContext.Database.EnsureCreated();
            orderContext.SaveChanges();
        }

        protected void PrintError(string error)
        {
            view.PrintToView(error);
            view.PrintToView("\n\nNo changes have been saved.\nPress any key to return to main menu.");
            Console.ReadKey(true);
            Console.Clear();
        }

    }
}
