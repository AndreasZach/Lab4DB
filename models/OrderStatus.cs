using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lab4DB
{
    [Table("Order_Status")]
    public class OrderStatus
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public int OrderStatusId { get; set; }

        //[ForeignKey("Order")]
        //public int OrderID { get; set; }

        [Column("current_status", TypeName= "nvarchar")]
        [MaxLength(15)]
        [Required]
        public string Status { get; set; }  // Switch to Enums if I expand.

        [Column("estimated_delivery", TypeName = "datetime2")]
        public DateTime? EstDeliveryDate { get; set; }

        //public virtual Order Order { get; set; }

    }
}
