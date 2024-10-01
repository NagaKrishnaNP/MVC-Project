using FirstMVCProject.Repository.IRepository;
using MVCProject.DataAccess.Data;
using MVCProject.Models;

namespace FirstMVCProject.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDB _db;
        public CategoryRepository(ApplicationDB db):base(db)
        {
            _db = db;
        }
        public void Update(Category category)
        {
           _db.Update(category);
        }
        }
    }
