using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Lab4DB
{
    class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<string> Items { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}
