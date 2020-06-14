using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCategories.Models
{
    [NotMapped]
    public class SingleCategoryViewModel
    {
        public Category Category { get; set; }
        public List<Product> AllProductsForCategory { get; set; }
        public int ProductIdToAdd { get; set; }
    }
}