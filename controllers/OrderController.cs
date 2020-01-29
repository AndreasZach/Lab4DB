using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4DB
{
    public class OrderController : Controller<Order>
    {
        public OrderController()
        {
            orderContext.Database.EnsureCreated();
            MainMenuControl();
        }

        protected override Order Model { get; set; }

        protected override List<Order> ModelList { get; set; }

        public void CreateOrder()
        {
            view.PrintToView("Enter customer name:");
            var custName = UserInputHandlerString(maxVal: 35);
            if (custName == null)
                return;
            view.PrintToView("Enter product name:");
            var prodName = UserInputHandlerString(maxVal: 50);
            if (prodName == null)
                return;
            orderContext.Orders.Add(
                new Order
                {
                    Id = new Guid(),
                    Customer = custName,
                    Product = prodName,
                    Date = DateTime.Now,
                    OrderStatus = new OrderStatus
                    {
                        Status = "Processing"
                    }
                });
            CommitDbChange();
            view.PrintToView("Order successully added.\n\nPress any key to return to the Main Menu");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void EditOrder()
        {
            ShowOrders();
            view.PrintToView("Enter the Order ID of the Order you wish to edit: ");
            int inputId = UserInputHandlerInt(ModelList.Count());
            if (inputId < 0)
            {
                PrintError("No Order matches you selection.");
                return;
            }
            Model = ModelList[inputId - 1];
            if (Model == null)
                return;
            Console.Clear();
            var input = 0;
            while (input != 4)
            {
                ShowOrderDetails(Model);
                view.PrintToView($"Which field do you wish to edit?\n[1] Customer\n[2] Status\n[3] Estimated date of delivery\n[4] Stop editing");
                input = UserInputHandlerInt(4);
                switch (input)
                {
                    case 1:
                        view.PrintToView($"Current customer name: {Model.Customer}\nEnter new customer name: ");
                        string name = UserInputHandlerString(35);
                        if (name == null)
                            goto default;
                        Model.Customer = name;
                        break;
                    case 2:
                        view.PrintToView($"Current status: {Model.OrderStatus.Status}\nEnter new status: ");
                        string status = UserInputHandlerString(15);
                        if (status == null)
                            goto default;
                        Model.OrderStatus.Status = status;
                        break;
                    case 3:
                        view.PrintToView($"Current estimated date of delivery: {Model.OrderStatus.Status}\nEnter new date (YYYY-MM-DD): ");
                        try
                        {
                            DateTime date = DateTime.Parse(UserInputHandlerString(10));
                            if (date < DateTime.Today)
                            {
                                PrintError("Estimatd time of delivery must be set to the current, or a future date.");
                                goto default;
                            }
                            Model.OrderStatus.EstDeliveryDate = date;
                        }
                        catch (FormatException)
                        {
                            PrintError("Invalid Date format. Date must be written as YYYY-MM-DD");
                            goto default;
                        }
                        break;
                    case 4:
                        CommitDbChange();
                        view.PrintToView("All changes have been Saved.\n\nPress any key to return to main menu.");
                        Console.ReadKey(true);
                        break;
                    default:
                        input = 4;
                        break;
                }
                Console.Clear();
            }
        }

        public void ShowOrders()
        {
            Console.Clear();
            ModelList = orderContext.Orders.ToList();
            if (ModelList.Count() == 0)
            {
                PrintError("No orders found.");
                return;
            }
            ModelList.ForEach(order => ShowOrderDetails(order));
        }

        public void ShowOrderDetails(Order order)
        {
            view.PrintToView(
                $"[{ModelList.IndexOf(order) + 1}]\n" +
                $"Customer Name: {order.Customer}\n" +
                $"Product: {order.Product}\n" +
                $"Order Date: {order.Date}\n" +
                $"Current Status: {order.OrderStatus.Status}\n" +
                $"Estimated date of delivery: {order.OrderStatus.EstDeliveryDate.ToString()}\n");
        }

        public void MainMenuControl()
        {
            int userChoice = 0;
            while (userChoice != 4)
            {
                view.PrintToView("Select an option:\n[1] Create a new order\n[2] Edit an existing order\n[3] Show order details\n[4] Exit");
                userChoice = UserInputHandlerInt(4);
                switch (userChoice)
                {
                    case 1:
                        CreateOrder();
                        break;
                    case 2:
                        EditOrder();
                        break;
                    case 3:
                        ShowOrders();
                        break;
                }
            }
        }
    }
}
