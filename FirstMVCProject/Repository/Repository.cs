using Microsoft.EntityFrameworkCore;
using MVCProject.DataAccess.Data;
using System.Linq.Expressions;
using static FirstMVCProject.Repository.IRepository.IRepository;

namespace FirstMVCProject.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDB _db;
        internal DbSet<T> Set;
        public Repository(ApplicationDB db)
        {
            _db = db;
            this.Set=_db.Set<T>();
        }
        public void Add(T entity)
        {
           _db.Add(entity);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            Set.RemoveRange(entity);
        }

       public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = Set;
            query=query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query=Set;
            return query.ToList();
        }
    }
}
