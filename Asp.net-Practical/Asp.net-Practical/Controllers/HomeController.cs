using Asp.net_Practical.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Asp.net_Practical.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Search(string query, int pageIndex = 1, int pageSize = 3)
        {
            if (string.IsNullOrEmpty(query))
            {
                var allProducts = _context.products
                    .Include(p => p.Category)
                    .Include(p => p.Brand)
                    .OrderBy(p => p.ProductId);

                var count = allProducts.Count();
                var items = allProducts.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

                var model = new PaginatedList<Product>(items, count, pageIndex, pageSize);
                return View("Index", model);
            }

            var results = _context.products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Where(p => p.Name.Contains(query) ||
                            p.Category.Name.Contains(query) ||
                            p.Brand.Name.Contains(query))
                .OrderBy(p => p.ProductId);

            var countResults = results.Count();
            var itemsResults = results.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            var modelResults = new PaginatedList<Product>(itemsResults, countResults, pageIndex, pageSize);

            return View("Index", modelResults);
        }

        public IActionResult Index(string query, int pageIndex = 1, int pageSize = 5)
        {
            IQueryable<Product> products = _context.products
                .Include(p => p.Category)
                .Include(p => p.Brand);

            if (!string.IsNullOrEmpty(query))
            {
                products = products.Where(p => p.Name.Contains(query) ||
                                                (p.Category != null && p.Category.Name.Contains(query)) ||
                                                (p.Brand != null && p.Brand.Name.Contains(query)));
            }

            var count = products.Count();
            var items = products.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            var model = new PaginatedList<Product>(items, count, pageIndex, pageSize);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
