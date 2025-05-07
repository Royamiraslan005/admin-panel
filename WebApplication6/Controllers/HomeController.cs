using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication6.DAL;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{

    public class HomeController : Controller
    {
        AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Product> products =await _context.products
                .Include(x=>x.Images)
                .ToListAsync();
            return View(products);
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            Product product=await _context.products
                .Include (x=>x.Images)
                .Include (x=>x.Category)
                .FirstOrDefaultAsync(p=>p.Id==id);
            return View(product);
        }
    }
}
