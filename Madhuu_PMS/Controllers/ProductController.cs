using Madhuu_PMS.Model.Entity;
using Madhuu_PMS.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Madhuu_PMS.Infrastructure.IRepository;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Madhuu_PMS.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICrudService<Product> _productCrudService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICrudService<Category> _CategoryCrudService;

        public ProductController(ICrudService<Product> productCrudService, UserManager<ApplicationUser> userManager, ICrudService<Category> CategoryCrudService)
        {
            _productCrudService = productCrudService;
            _userManager = userManager;
            _CategoryCrudService = CategoryCrudService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productList = await _productCrudService.GetAllAsync();
            return View(productList);
        }

        [HttpGet]
        
        public async Task<IActionResult> AddEdit(int id = 0)
        {
            Product product = new Product { IsAvailable = true };
            ViewBag.CategoryInfos = await _CategoryCrudService.GetAllAsync(p => p.IsActive);

            if (id > 0)
            {
                product = await _productCrudService.GetAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> AddEdit(Product product)
        {
            if (!ModelState.IsValid)
            {
                TempData["error"] = "Please fill in the required fields correctly.";
                return View(product);
            }

            try
            {
                var user = _userManager.GetUserId(User);

                if (product.productImage != null)
                {
                    string fileDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProductImage");

                    if (!Directory.Exists(fileDirectory))
                    {
                        Directory.CreateDirectory(fileDirectory);
                    }

                    string uniqueFileName = Guid.NewGuid() + "_" + product.productImage.FileName;
                    string filePath = Path.Combine(fileDirectory, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await product.productImage.CopyToAsync(fileStream);
                        product.ImageUrl = "ProductImage/" + uniqueFileName;
                    }
                }

                if (product.Id == 0)
                {
                    product.CreatedDate = DateTime.Now;
                    product.CreatedBy = user;
                    await _productCrudService.InsertAsync(product);
                    TempData["success"] = "Data added successfully.";
                }
                else
                {
                    var productInfo = await _productCrudService.GetAsync(product.Id);
                    if (productInfo == null)
                    {
                        return NotFound();
                    }

                    productInfo.ProductName = product.ProductName;
                    productInfo.ProductDescription = product.ProductDescription;
                    productInfo.Rate = product.Rate;
                    productInfo.quantity = product.quantity;
                    productInfo.CategoryId = product.CategoryId;
                    productInfo.batchNo = product.batchNo;
                    productInfo.ExpiryDate = product.ExpiryDate;
                    productInfo.IsAvailable = product.IsAvailable;
                    productInfo.ImageUrl = product.ImageUrl;
                    productInfo.productionDate = product.productionDate;
                    

                    await _productCrudService.UpdateAsync(productInfo);
                    TempData["success"] = "Data updated successfully.";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["error"] = "An error occurred while processing your request.";
                return View(product);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productCrudService.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productCrudService.DeleteAsync(product);
            TempData["success"] = "Data deleted successfully.";
            return RedirectToAction(nameof(Index));
        }
    }
}
