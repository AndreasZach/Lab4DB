using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4DB
{
    class OrderStatus
    {
        public int Id { get; set; }
        public DateTime DateReceived { get; set; }
        public DateTime EstDeliveryDate { get; set; }
        public string Status { get; set; }

    }
}
