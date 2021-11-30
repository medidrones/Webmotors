using System.Collections.Generic;

namespace Webmotors.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        T Insert(T obj);
        T Update(T obj);
        IEnumerable<T> SelectAll();
        T Select(int id);
        void Delete(T obj);
    }
}
