using System;

namespace Lab4DB
{
    // TODO: Find a more effective solution to handle user input (return int or string) in controllers.
    // TODO: Find a better way to handle errors. (Send error messages to method thath handles errors?)
    // TODO: Database communication layer with methods for saving changes, ensure created, async etc etc? (Handle model updates?)
    // TODO: Find a way to auto-increment ID with annotations.
    // TODO: Use UriBuilder instead of connection strings?

    // TODO before turn-in: Put program.cs menu into PrintMainMenu method and rename that method. ((Klart)).
    // TODO before turn-in: Replace model ID with GUID. Choose object to edit by position in list instead of ID. ((Klart))
    // TODO before turn-in: In innputHandlers, replace Console.ReadLine() with Console.ReadKey() and change errorhandling accordingly ((Klart))
    // TODO before turn-in: Find a way to convert numpad keys to int
    class Program
    {
        static void Main(string[] args)
        {
            var orderControl = new OrderController();
        }
    }
}
