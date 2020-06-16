using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Display(Name = "Order")]
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Customer Buyer { get; set; }
        public Product ItemBought { get; set; }
    }
}