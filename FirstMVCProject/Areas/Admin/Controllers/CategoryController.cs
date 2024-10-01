using FirstMVCProject.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using MVCProject.DataAccess.Data;
using MVCProject.Models;
using System.Linq.Expressions;

namespace FirstMVCProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork categRepo;
        public CategoryController(IUnitOfWork db)
        {
            categRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> categorylist = categRepo.CategoryRepository.GetAll().ToList();
            return View(categorylist);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category categoryObj)
        {
            if (categoryObj.CategoryName == categoryObj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("categoryname", "Category Name and Display Order should not be the same");
            }
            if (ModelState.IsValid)
            {
                categRepo.CategoryRepository.Add(categoryObj);
                categRepo.Save();
                TempData["success"] = "CATEGORY CREATED SUCCESSFULLY";
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category categoryFromDb = categRepo.CategoryRepository.Get(u => u.CategoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category categoryObj)
        {
            if (ModelState.IsValid)
            {
                categRepo.CategoryRepository.Update(categoryObj);
                categRepo.Save();
                TempData["success"] = "CATEGORY EDITED SUCCESSFULLY";
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            Category categoryFromDb = categRepo.CategoryRepository.Get(u => u.CategoryId == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category categoryForDelete = categRepo.CategoryRepository.Get(u => u.CategoryId == id);
            if (categoryForDelete == null)
            {
                return NotFound();
            }
            categRepo.CategoryRepository.Delete(categoryForDelete);
            categRepo.Save();
            TempData["success"] = "CATEGORY DELETED SUCCESSFULLY";
            return RedirectToAction("Index");
        }
    }
}
