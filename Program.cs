using System;

namespace Lab4DB
{
    // 1. Skapa en Models folder med klasser för databas-objekt, samt passande annoteringar för dessa.
    //      Order klass: Innehåller beställningens specifikationer, samt en navigational property till OrderStatus.
    //      OrderStatus klass: Innehåller produktion-information/status för sin tillhörande Order.
    // 2. Skapa Model klass som innehåller model object samt business logic.
    // 3. Skapa Controller basklass med subklasser för de models som finns. (Mestadels för att kunna utveckla projektet senare.)
    // 4. Skapa en View klass för Console. (Implementera API för web/wpf/xamarin om jag har tid över)
    // 5. Skapa en klass vars jobb är att ansluta, hämta och skicka data till/från en databas.
    // 6. Börja med strängar som properties i model-klasser, utöka med t.ex Brand, Category, Product klasser om tid finns.
    // Vill strukturera koden så att man kan implementera t.ex Rest API m.m vid senare tillfälle,
    // med andra ord kunna bygga på grunden och göra detta till ett större projekt i framtiden.


    // TODO: Find a more effective solution to handle user input (return int or string) in controllers.
    // TODO: Find a better way to handle errors. (Method to handle errors?)
    // TODO: Database communication layer with methods for saving changes, ensure created, async etc etc? (Handle model updates?)
    // TODO: See if there is a better way of creates a DB connections than just using strings.
    // TODO: Find a way to auto-increment ID with annotations.
    class Program
    {
        static void Main(string[] args)
        {
            var orderControl = new OrderController();
            int userChoice = 0;
            while (userChoice != 4)
            {
                orderControl.PrintMainMenu();
                userChoice = orderControl.UserInputHandlerInt(4);
                switch (userChoice)
                {
                    case 1:
                        orderControl.CreateOrder();
                        break;
                    case 2:
                        orderControl.EditOrder();
                        break;
                    case 3:
                        orderControl.ShowOrders();
                        break;
                }
                Console.Clear();
            }


        }
    }
}
