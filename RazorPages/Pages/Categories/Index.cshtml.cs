using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Data;
using RazorPages.Models;

namespace RazorPages.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDB _db;
        public List<Category> categoryList {  get; set; }
        public IndexModel(ApplicationDB db)
        {
            _db = db;
        }
        public void OnGet()
        {
            categoryList=_db.categoryRazor.ToList();
        }
    }
}
