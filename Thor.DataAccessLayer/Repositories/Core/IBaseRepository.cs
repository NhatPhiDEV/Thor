using System.Collections.Generic;

namespace Thor.DataAccessLayer.Repositories.Core
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
