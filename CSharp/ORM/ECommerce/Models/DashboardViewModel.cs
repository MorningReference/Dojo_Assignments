using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    [NotMapped]
    public class DashboardViewModel
    {
        public List<Product> AllProducts { get; set; }
        public List<Order> RecentOrders { get; set; }
        public List<Customer> NewCustomers { get; set; }
    }
}