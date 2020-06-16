using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    [NotMapped]
    public class OrdersViewModel
    {
        public Order OrderToAdd { get; set; }
        public List<Order> AllOrders { get; set; }
        public List<Customer> AllCustomers { get; set; }
        public List<Product> AllProducts { get; set; }
    }
}