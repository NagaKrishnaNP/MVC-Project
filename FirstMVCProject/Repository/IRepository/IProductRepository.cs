using MVCProject.Models;
using static FirstMVCProject.Repository.IRepository.IRepository;

namespace FirstMVCProject.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
