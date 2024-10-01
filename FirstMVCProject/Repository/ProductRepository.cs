using FirstMVCProject.Repository.IRepository;
using MVCProject.DataAccess.Data;
using MVCProject.Models;

namespace FirstMVCProject.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDB _db;
        public ProductRepository(ApplicationDB db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            _db.Update(product); 
        }
    }
}
