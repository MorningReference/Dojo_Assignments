using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        private ECommerceContext db;
        public HomeController(ECommerceContext context)
        {
            db = context;
        }
        [HttpGet("")]
        public IActionResult Dashboard()
        {
            DashboardViewModel wrapper = new DashboardViewModel();
            wrapper.AllProducts = db.Products
                .Take(5)
                .ToList();
            wrapper.RecentOrders = db.Orders
                .Include(o => o.Buyer)
                .Include(o => o.ItemBought)
                .OrderByDescending(o => o.CreatedAt)
                .Take(3)
                .ToList();
            wrapper.NewCustomers = db.Customers
                .OrderByDescending(c => c.CreatedAt)
                .Take(3)
                .ToList();
            return View("Dashboard", wrapper);
        }

        [HttpGet("orders")]
        public IActionResult Orders()
        {
            OrdersViewModel wrapper = new OrdersViewModel();
            wrapper.AllOrders = db.Orders
                .OrderByDescending(o => o.CreatedAt)
                .Include(o => o.Buyer)
                .Include(o => o.ItemBought)
                .ToList();

            wrapper.AllCustomers = db.Customers.ToList();
            wrapper.AllProducts = db.Products.ToList();

            return View("Orders", wrapper);
        }

        [HttpPost("order/create")]
        public IActionResult CreateOrder(OrdersViewModel newOrder)
        {
            var RetrievedProduct = db.Products.FirstOrDefault(p => p.ProductId == newOrder.OrderToAdd.ProductId);
            RetrievedProduct.Quantity -= newOrder.OrderToAdd.ProductQuantity;
            RetrievedProduct.UpdatedAt = DateTime.Now;
            db.Add(newOrder.OrderToAdd);
            db.Products.Update(RetrievedProduct);
            db.SaveChanges();
            return RedirectToAction("Orders");
        }

        [HttpGet("customers")]
        public IActionResult Customers()
        {
            CustomersViewModel wrapper = new CustomersViewModel();
            wrapper.AllCustomers = db.Customers
                .OrderByDescending(c => c.CreatedAt)
                .ToList();

            return View("Customers", wrapper);
        }

        [HttpPost("customer/create")]
        public IActionResult CreateCustomer(CustomersViewModel newCustomer)
        {
            CustomersViewModel wrapper = new CustomersViewModel();
            // wrapper.AllCustomers = db.Customers
            //     .OrderByDescending(c => c.CreatedAt)
            //     .ToList();
            // if (ModelState.IsValid)
            // {
            // if (db.Customers.Any(c => c.Name == newCustomer.Name))
            // {
            //     ModelState.AddModelError("Name", "A customer with this name already exists");
            //     return View("Customers", wrapper);
            // }
            db.Add(newCustomer.CustomerToAdd);
            db.SaveChanges();
            return RedirectToAction("Customers");
            // }
            // return View("Customers", wrapper);
        }

        [HttpGet("products")]
        public IActionResult Products()
        {
            ProductsViewModel wrapper = new ProductsViewModel();
            wrapper.AllProducts = db.Products.ToList();
            return View("Products", wrapper);
        }

        [HttpPost("product/create")]
        public IActionResult CreateProduct(ProductsViewModel newProduct)
        {
            db.Add(newProduct.ProductToAdd);
            db.SaveChanges();
            return RedirectToAction("Products");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
