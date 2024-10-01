using MVCProject.Models;
using static FirstMVCProject.Repository.IRepository.IRepository;

namespace FirstMVCProject.Repository.IRepository
{
    public interface ICategoryRepository:IRepository<Category>
    {
        void Update(Category category);
    }
}
