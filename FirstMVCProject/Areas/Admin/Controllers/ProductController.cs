using FirstMVCProject.Repository;
using FirstMVCProject.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Models;
using MVCProject.Models.ViewModels;


namespace FirstMVCProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController:Controller
    {
            private readonly IUnitOfWork productRepo;
            public ProductController(IUnitOfWork db)
            {
                productRepo = db;
            }
            public IActionResult Index()
            {
                List<Product> categorylist = productRepo.ProductRepository.GetAll().ToList();
                return View(categorylist);
            }

            public IActionResult Upsert(int? id)
            {
            ProductVM productVM = new()
            {
                selectListItems= productRepo.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()
                }),
                Product=new Product()
            };
            if (id == 0 || id == null)
                return View(productVM);
            else
            {
                productVM.Product=productRepo.ProductRepository.Get(u=>u.ProductId==id);
                return View(productVM);
            }
            }

        [HttpPost]
        public IActionResult Upsert(ProductVM categoryObj,IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                productRepo.ProductRepository.Add(categoryObj.Product);
                productRepo.Save();
                TempData["success"] = "CATEGORY CREATED SUCCESSFULLY";
                return RedirectToAction("Index");
            }
            else
            {
                categoryObj.selectListItems = productRepo.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()
                });
                return View(categoryObj);
            }
        }

            public IActionResult Delete(int? id)
            {
                if (id == 0 || id == null)
                {
                    return NotFound();
                }
            Product categoryFromDb = productRepo.ProductRepository.Get(u => u.ProductId == id);
            if (categoryFromDb == null)
                {
                    return NotFound();
                }
                return View(categoryFromDb);
            }

            [HttpPost, ActionName("Delete")]
            public IActionResult DeletePOST(int? id)
            {
            Product categoryForDelete = productRepo.ProductRepository.Get(u => u.ProductId == id);
            if (categoryForDelete == null)
                {
                    return NotFound();
                }
                productRepo.ProductRepository.Delete(categoryForDelete);
                productRepo.Save();
                TempData["success"] = "CATEGORY DELETED SUCCESSFULLY";
                return RedirectToAction("Index");
            }
        }
}

