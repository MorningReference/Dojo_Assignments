using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    [NotMapped]
    public class ProductsViewModel
    {
        public Product ProductToAdd { get; set; }
        public List<Product> AllProducts { get; set; }
    }
}