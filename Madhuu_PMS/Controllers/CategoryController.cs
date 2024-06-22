using Madhuu_PMS.Model.Entity;
using Madhuu_PMS.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Madhuu_PMS.Infrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using Madhuu_PMS.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace Madhuu_PMS.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICrudService<Category> _CategoryCrudService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryController(ICrudService<Category> CategoryCrudService, UserManager<ApplicationUser> userManager)
        {
            _CategoryCrudService = CategoryCrudService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var CategoryList = await _CategoryCrudService.GetAllAsync();
            return View(CategoryList);
        }

       
        public async Task<IActionResult> AddEdit(int id = 0)
        {
            Category Category = new Category { IsActive = true };
            if (id > 0)
            {
                Category = await _CategoryCrudService.GetAsync(id);
                if (Category == null)
                {
                    return NotFound();
                }
            }
            return View(Category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEdit(Category Category)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Insert Data Properly";
                return View(Category);
            }

            try
            {
                var user = _userManager.GetUserId(User);
                if (Category.Id == 0)
                {
                    Category.CreatedDate = DateTime.Now;
                    Category.CreatedBy = user;
                    await _CategoryCrudService.InsertAsync(Category);
                    TempData["success"] = "Data Added Successfully";
                }
                else
                {
                    var CategoryInfo = await _CategoryCrudService.GetAsync(Category.Id);
                    if (CategoryInfo == null)
                    {
                        return NotFound();
                    }
                    CategoryInfo.CategoryName = Category.CategoryName;
                    CategoryInfo.CategoryDescription = Category.CategoryDescription;
                    CategoryInfo.IsActive = Category.IsActive;

                    await _CategoryCrudService.UpdateAsync(CategoryInfo);
                    TempData["success"] = "Data Updated Successfully";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["error"] = "An error occurred while processing your request.";
                return View(Category);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var Category = await _CategoryCrudService.GetAsync(id);
            if (Category == null)
            {
                return NotFound();
            }
            await _CategoryCrudService.DeleteAsync(Category);
            TempData["success"] = "Data Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }
    }
}
