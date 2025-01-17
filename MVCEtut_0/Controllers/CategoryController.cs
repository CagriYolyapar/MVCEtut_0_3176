using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEtut_0.Models.ContextClasses;
using MVCEtut_0.Models.Entities;
using MVCEtut_0.Models.PageVms.CategoryControllerProcess;
using MVCEtut_0.Models.PureVms.RequestModels.Categories;
using MVCEtut_0.Models.PureVms.ResponseModels.Categories;

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
            //List<Category>
            //Category
            List<Category> categories =await _context.Categories.ToListAsync();
            List<CategoryResponseModel> categoryResponse = categories.Select(x => new CategoryResponseModel
            {
                Id  = x.Id,
                CategoryName = x.CategoryName,
            }).ToList();

            CategoryResponseModel? popularCategory =  _context.Categories.Where(x => x.Id == 5).Select(x => new CategoryResponseModel
            {
                Id = x.Id,
                CategoryName = x.CategoryName
            }).FirstOrDefault();

            CategoryProcessPageVm cpVm = new()
            {
                Categories = categoryResponse,
                TheMostPopularCategory = popularCategory
            };



            return View(cpVm);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryCreateProcessPageVm model)
        {
            Category c = new()
            {
                CategoryName = model.Category.CategoryName
            };

            AppUser appUser = new()
            {
                UserName = model.AppUser.UserName,
                Password = model.AppUser.Password
            };

            await  _context.Categories.AddAsync(c);
            await _context.AppUsers.AddAsync(appUser);
            await _context.SaveChangesAsync();
            return RedirectToAction("CategoryList");
        }

        public async Task<IActionResult> UpdateCategory(int id)
        {
            UpdateCategoryRequestModel? category = await _context.Categories.Where(x => x.Id == id).Select(x => new UpdateCategoryRequestModel
            {
                Id = x.Id,
                CategoryName = x.CategoryName
            }).FirstOrDefaultAsync();

            CategoryUpdateProcessPageVm cpVm = new()
            {
                Category = category
            };

            return View(cpVm);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequestModel category)
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
