using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsCategories.Models;

namespace ProductsCategories.Controllers
{
    public class ProductCategoryController : Controller
    {
        private ProductCategoryContext db;
        public ProductCategoryController(ProductCategoryContext context)
        {
            db = context;
        }

        [HttpGet("products")]
        public IActionResult Products()
        {
            ViewBag.AllProducts = db.Products.ToList();
            return View("Products");
        }

        [HttpGet("categories")]
        public IActionResult Categories()
        {
            ViewBag.AllCategories = db.Categories.ToList();
            return View("Categories");
        }

        [HttpPost("product/create")]
        public IActionResult CreateProduct(Product newProduct)
        {
            if (ModelState.IsValid)
            {
                db.Add(newProduct);
                db.SaveChanges();
                return RedirectToAction("SingleProduct", new { productId = newProduct.ProductId });
            }
            return View("Products");
        }

        [HttpPost("category/create")]
        public IActionResult CreateCategory(Category newCategory)
        {
            if (ModelState.IsValid)
            {
                db.Add(newCategory);
                db.SaveChanges();
                return RedirectToAction("SingleCategory", new { categoryId = newCategory.CategoryId });
            }
            return View("Categories");
        }

        [HttpGet("product/{productId}")]
        public IActionResult SingleProduct(int productId)
        {
            var ProductWithCategories = db.Products
                .Include(p => p.Categories)
                .ThenInclude(a => a.Category)
                .FirstOrDefault(p => p.ProductId == productId);

            List<Category> AllCategories = db.Categories
                .Include(c => c.Products)
                .ThenInclude(a => a.Product)
                .Where(c => c.Products.All(a => a.Product.ProductId != productId)).ToList();

            SingleProductViewModel SingleProduct = new SingleProductViewModel();
            SingleProduct.Product = ProductWithCategories;
            SingleProduct.AllCategoriesForProduct = AllCategories;

            return View("SingleProduct", SingleProduct);
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult SingleCategory(int categoryId)
        {
            var CategoryWithProducts = db.Categories
                .Include(c => c.Products)
                .ThenInclude(a => a.Product)
                .FirstOrDefault(c => c.CategoryId == categoryId);


            // var allprods = db.Products.Contains()
            List<Product> AllProducts = db.Products
                .Include(p => p.Categories)
                .ThenInclude(a => a.Category)
                .Where(p => p.Categories.All(a => a.Category.CategoryId == categoryId)).ToList();

            SingleCategoryViewModel SingleCategory = new SingleCategoryViewModel();
            SingleCategory.Category = CategoryWithProducts;
            SingleCategory.AllProductsForCategory = AllProducts;
            // ViewBag.ProductsToAdd = AllProducts.Except(categoryWithProducts.Products);

            return View("SingleCategory", SingleCategory);
        }

        [HttpPost("product/{productId}/update")]
        public IActionResult AddCategoryToProduct(int categoryIdToAdd, int productId)
        {
            var RetrievedProduct = db.Products
                .Include(p => p.Categories)
                .ThenInclude(a => a.Category)
                .FirstOrDefault(p => p.ProductId == productId);

            var RetrievedCategory = db.Categories
                .FirstOrDefault(c => c.CategoryId == categoryIdToAdd);

            // Association associationToAdd = new Association();
            // associationToAdd.ProductId = productId;
            // associationToAdd.CategoryId = categoryIdToAdd;
            // associationToAdd.Product = db.Products.FirstOrDefault(p => p.ProductId == productId);
            // associationToAdd.Category = db.Categories.FirstOrDefault(c => c.CategoryId == categoryIdToAdd);

            RetrievedProduct.Categories.Add(new Association
            {
                Product = RetrievedProduct,
                Category = RetrievedCategory
            });

            // db.Associations.Update(associationToAdd);
            db.SaveChanges();
            return RedirectToAction("SingleProduct", new { productId = productId });
        }

        [HttpPost("category/{categoryId}/update")]
        public IActionResult AddProductToCategory(int productIdToAdd, int categoryId)
        {
            var RetrievedCategory = db.Categories
                .Include(p => p.Products)
                .ThenInclude(a => a.Product)
                .FirstOrDefault(p => p.CategoryId == categoryId);

            var RetrievedProduct = db.Products
                .FirstOrDefault(p => p.ProductId == productIdToAdd);
            // Association associationToAdd = new Association();
            // associationToAdd.ProductId = categoryId;
            // associationToAdd.CategoryId = productIdToAdd;
            // associationToAdd.Category = db.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            // associationToAdd.Product = db.Products.FirstOrDefault(c => c.ProductId == productIdToAdd);

            RetrievedCategory.Products.Add(new Association
            {
                Category = RetrievedCategory,
                Product = RetrievedProduct
            });

            // db.Associations.Update(associationToAdd);
            db.SaveChanges();
            return RedirectToAction("SingleCategory", new { categoryId = categoryId });
        }
    }
}