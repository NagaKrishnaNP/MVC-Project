using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDB _db;
        public Category category { get; set; }

        public EditModel(ApplicationDB db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            category = _db.categoryRazor.Find(id);
        }

        public IActionResult OnPost()
        {
            _db.Update(category);
            _db.SaveChanges();
            TempData["success"] = "CATEGORY EDITED SUCCESSFULLY";
            return RedirectToPage("Index");
        }
    }
}
