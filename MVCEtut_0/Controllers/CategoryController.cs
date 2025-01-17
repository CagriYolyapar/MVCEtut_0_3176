using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEtut_0.Models.ContextClasses;
using MVCEtut_0.Models.Entities;

namespace MVCEtut_0.Controllers
{
    public class CategoryController : Controller
    {
        readonly MyContext _context;

        public CategoryController(MyContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> CategoryList()
        {
            
            List<Category> categories =await _context.Categories.ToListAsync();
            return View(categories);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            await  _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            return View(await _context.Categories.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            Category originalValue = await _context.Categories.FindAsync(category.Id);
            originalValue.CategoryName = category.CategoryName;
            await _context.SaveChangesAsync();

            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            _context.Remove(await _context.Categories.FindAsync(id));
            await _context.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }
    }
}
