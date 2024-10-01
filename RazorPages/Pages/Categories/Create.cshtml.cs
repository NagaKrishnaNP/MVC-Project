using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDB _db;
        public Category category { get; set; }
        public CreateModel(ApplicationDB db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _db.Add(category);
            _db.SaveChanges();
            TempData["success"] = "CATEGORY CREATED SUCCESSFULLY";
            return RedirectToPage("Index");
        }
    }
}
