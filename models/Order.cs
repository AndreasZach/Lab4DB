using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lab4DB
{
    [Table("Orders")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column("customer_name", TypeName = "nvarchar")]
        [MaxLength(35)]
        [Required]
        public string Customer { get; set; } // Change to virtual Customer Customer if I expand the project.

        [Column("product", TypeName = "nvarchar")]
        [MaxLength(50)]
        [Required]
        public string Product { get; set; } // Change to virtual Ilist<Product> Products if I expand the project.

        [Column("order_date", TypeName = "datetime2")]
        [Required]
        public DateTime Date { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }
    }
}
