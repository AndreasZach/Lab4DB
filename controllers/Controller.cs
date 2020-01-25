using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4DB
{
    public class Controller<T>
    {
        protected OrdersDbContext orderContext = new OrdersDbContext(
            @"https://localhost:8081", 
            @"C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
            "OrdersDB");

        protected int IdCounter = 1;

        protected ConsoleView view = new ConsoleView();

        protected virtual T Model { get; set; }

        protected virtual List<T> ModelList { get; set; }

        public string UserInputHandlerString(int? maxVal = null)
        {
            string input;

            input = Console.ReadLine(); // Error handling needed.
            if (String.IsNullOrWhiteSpace(input) || input.Length < 1)
                throw new Exception("Entry must be at least one character long.");
            if (input.Length > maxVal)
                throw new Exception($"Entry cannot be longer than {maxVal} characters.");

            return input;
        }
        
        public int UserInputHandlerInt(int maxVal, int minVal = 1)
        {
            int input;
            if (!Int32.TryParse(Console.ReadLine(), out input)) // Error handling needed.
                throw new Exception("Invalid input. Only integers are supported for this entry.");
            if (input < minVal || input > maxVal)
                throw new Exception($"Entry can only be between 1 and {maxVal}");

            return input;
        }

        public void PrintMainMenu()
        {
            view.PrintToView("Select an option:\n[1] Create a new order\n[2] Edit an existing order\n[3] Show order details\n[4] Exit");
        }

    }
}
