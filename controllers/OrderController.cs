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

        public async void CreateOrder()
        {
            view.PrintToView("Enter customer name:");
            var custName = UserInputHandlerString(maxVal: 35);
            view.PrintToView("Enter product name:");
            var prodName = UserInputHandlerString(maxVal: 50);
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
            await orderContext.SaveChangesAsync();
        }

        public async void EditOrder()
        {
            ShowOrders();
            if (ModelList.Count() == 0)
                return;

            view.PrintToView("Enter the Order ID of the Order you wish to edit: ");
            Model = ModelList.Where(o => o.Id == UserInputHandlerInt(ModelList.Select(o => o.Id).Max())).FirstOrDefault();
            if (Model == null)
            {
                view.PrintToView("No Order ID matches you selection.");
            }
            Console.Clear();

            ShowOrderDetails(Model);

            var input = 0;
            while (input != 4)
            {
                view.PrintToView($"Which field do you wish to edit?\n[1] Customer\n[2] Status\n[3] Estimated date of delivery\n[4] Stop editing");
                input = UserInputHandlerInt(4);
                switch (input)
                {
                    case 1:
                        view.PrintToView($"Current customer name: {Model.Customer}\nEnter new customer name: ");
                        Model.Customer = UserInputHandlerString(35);
                        break;
                    case 2:
                        view.PrintToView($"Current status: {Model.OrderStatus.Status}\nEnter new status: ");
                        Model.OrderStatus.Status = UserInputHandlerString(15);
                        break;
                    case 3:
                        view.PrintToView($"Current estimated date of delivery: {Model.OrderStatus.Status}\nEnter new date (YYYY-MM-DD): ");
                        try
                        {
                            Model.OrderStatus.EstDeliveryDate = DateTime.Parse(UserInputHandlerString(10));
                        }
                        catch (FormatException)
                        {
                            view.PrintToView("Invalid Date format. Date must be written as YYYY-MM-DD");
                        }
                        catch(Exception e)
                        {
                            view.PrintToView(e.Message);
                        }
                        break;
                }
                Console.Clear();
            }
            await orderContext.SaveChangesAsync();
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
