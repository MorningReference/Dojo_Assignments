using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Display(Name = "Image (url):")]
        public string ImageUrl { get; set; }
        [Display(Name = "Description:")]
        public string Description { get; set; }
        [Display(Name = "Initial Quantity:")]
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Order> Orders { get; set; }
    }
}