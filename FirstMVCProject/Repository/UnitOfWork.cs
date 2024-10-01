using FirstMVCProject.Repository.IRepository;
using MVCProject.DataAccess.Data;

namespace FirstMVCProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository CategoryRepository { get; private set; }
        public IProductRepository ProductRepository { get; private set; }
        private ApplicationDB _db;
        public UnitOfWork(ApplicationDB db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            ProductRepository = new ProductRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
