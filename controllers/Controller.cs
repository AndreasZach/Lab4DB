using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4DB
{
    public class Controller<T>
    {
        protected OrdersDbContext orderContext = new OrdersDbContext(); // Cosmos connection string, Key and DBname needed
        protected ConsoleView view = new ConsoleView();
        protected virtual T Model { get; set; }

        // public void SetModel(T model)
        // {
        //     Model = model;
        // }
        // 
        // public T GetModel()
        // {
        //     return Model;
        // }

        public void UserInputHandler() // Make a class that can check for bad user input
        {

        }

        public void PrintMainMenu()
        {
            view.PrintToView("Select an option:\n[1] Create a new order\n[2] Edit an existing order\n[3] Show order details\n[4] Exit");
        }
    }
}
