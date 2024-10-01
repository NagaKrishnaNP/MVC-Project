using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDB _db;
        public Category category { get; set; }

        public DeleteModel(ApplicationDB db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            category = _db.categoryRazor.Find(id);
        }

        public IActionResult OnPost()
        {
            _db.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "CATEGORY DELETED SUCCESSFULLY";
            return RedirectToPage("Index");
        }
    }
}
