using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4DB
{
    class OrderController : Controller<Order>
    {
        protected override Order Model { get; set; }

        public async void CreateOrder()
        {
            view.PrintToView("Enter customer name:");
            var custName = Console.ReadLine();
            if (custName.Length > 35)
                throw new Exception("Customer name cannot contain more than 35 characters");
            view.PrintToView("Enter product name:");
            var prodName = Console.ReadLine();
            if (prodName.Length > 50)
                throw new Exception("Product name cannot contain more than 50 characters");

            orderContext.Orders.Add(
                new Order
                {
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

        public void EditOrder()
        {
            view.PrintToView("");
        }
    }
}
