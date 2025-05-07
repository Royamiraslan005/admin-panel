using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.DependencyResolver;
using WebApplication6.DAL;
using WebApplication6.Models;

namespace WebApplication6.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ProductController : Controller
    {
        AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.products.ToListAsync();

            return View(categories);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product slider)
        {

            if (!slider.formFile.ContentType.Contains("image"))
            {
                return View();
            }

            var safeFileName = Path.GetFileName(slider.formFile.FileName);


            string fileName;

            if (safeFileName.Length > 100)
            {
                fileName = Guid.NewGuid().ToString() + safeFileName.Substring(safeFileName.Length - 64);
            }
            else
            {
                fileName = Guid.NewGuid().ToString() + safeFileName;
            }




            var filePath = Path.Combine("C:\\Users\\I Novbe\\source\\repos\\WebApplication6\\WebApplication6\\wwwroot\\images\\", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                slider.formFile.CopyTo(stream);
            }


            slider.ImgUrl = fileName;

            await _context.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var c = await _context.products.FindAsync(id);


            _context.products.Remove(c!);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var c = _context.products.FirstOrDefault(x => x.Id == id);
            return View(c);
        }


        [HttpPost]
        public async Task<IActionResult> Update(Product slider)
        {

            if (slider.formFile != null)
            {
                if (!slider.formFile.ContentType.Contains("image"))
                {
                    return View();
                }

                var safeFileName = Path.GetFileName(slider.formFile.FileName);
                string fileName;

                if (safeFileName.Length > 100)
                {
                    fileName = Guid.NewGuid().ToString() + safeFileName.Substring(safeFileName.Length - 64);
                }
                else
                {
                    fileName = Guid.NewGuid().ToString() + safeFileName;
                }

                var filePath = Path.Combine("C:\\Users\\I Novbe\\source\\repos\\Kider\\Kider\\wwwroot\\images\\", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    slider.formFile.CopyTo(stream);
                }

                slider.ImgUrl = fileName;


                _context.products.Update(slider);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {

                _context.Update(slider);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
    }
}
