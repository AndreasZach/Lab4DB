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


        // TODO: find a generic way to interact with the Controllers
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
