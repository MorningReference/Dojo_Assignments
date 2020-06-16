using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    [NotMapped]
    public class CustomersViewModel
    {
        public Customer CustomerToAdd { get; set; }
        public List<Customer> AllCustomers { get; set; }
    }
}