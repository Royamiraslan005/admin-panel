using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using WebApplication6.DAL;
using WebApplication6.Models;

namespace WebApplication6.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CategoryController : Controller
    {
        AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = _context.categories.Include(x => x.Products).ToList();

            return View(categories);
        }


        public IActionResult Create()
        {
            return View();
        }

       
    }
}
