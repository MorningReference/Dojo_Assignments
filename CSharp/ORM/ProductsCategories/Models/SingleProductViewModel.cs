using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsCategories.Models
{
    [NotMapped]
    public class SingleProductViewModel
    {
        public Product Product { get; set; }
        public List<Category> AllCategoriesForProduct { get; set; }
        public int CategoryIdToAdd { get; set; }
    }
}