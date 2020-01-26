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
                    Id = (IdCounter+=1),
                    Customer = custName,
                    Product = prodName,
                    Date = DateTime.Now,
                    OrderStatus = new OrderStatus
                    {
                        Status = "Processing"
                    }
                });
            CommitDbChange();
        }

        public void EditOrder()
        {
            ShowOrders();

            view.PrintToView("Enter the Order ID of the Order you wish to edit: ");
            int inputId = UserInputHandlerInt(ModelList.Select(id => id.Id).Max());
            Model = ModelList.Where(o => o.Id == inputId).FirstOrDefault();
            if (Model == null)
            {
                view.PrintToView("No Order ID matches you selection.");
                return;
            }

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
                            Model.OrderStatus.EstDeliveryDate = date;
                        }
                        catch (FormatException)
                        {
                            view.PrintToView("Invalid Date format. Date must be written as YYYY-MM-DD");
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
                        view.PrintToView("No changes have been saved.\n\nPress any key to return to main menu.");
                        Console.ReadKey(true);
                        break;
                }
                Console.Clear();
            }
        }

        public void ShowOrders()
        {
            ModelList = orderContext.Orders.ToList();
            if (ModelList.Count() == 0)
            {
                view.PrintToView("No orders found.");
                Console.Clear();
                return;
            }
            ModelList.ForEach(order => ShowOrderDetails(order));
            view.PrintToView("Press any key to continue...");
            Console.ReadKey(true);
        }

        public void ShowOrderDetails(Order order)
        {
            view.PrintToView($"\n\n" +
                $"Order ID: {order.Id}\n" +
                $"Customer Name: {order.Customer}\n" +
                $"Product: {order.Product}\n" +
                $"Order Date: {order.Date}\n" +
                $"Current Status: {order.OrderStatus.Status}\n" +
                $"Estimated date of delivery: {order.OrderStatus.EstDeliveryDate.ToString() ?? "Unknown"}\n\n");
        }
    }
}
