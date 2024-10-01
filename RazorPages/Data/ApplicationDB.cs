using Microsoft.EntityFrameworkCore;
using RazorPages.Models;

namespace RazorPages.Data
{
    public class ApplicationDB:DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options):base(options) { }
        public DbSet<Category> categoryRazor {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId=1,CategoryName="Action",DisplayOrder=1},
                new Category { CategoryId = 2, CategoryName = "Horror", DisplayOrder = 2 },
                new Category { CategoryId = 3, CategoryName = "Adevnture", DisplayOrder = 3 }
                );
        }
    }
}
