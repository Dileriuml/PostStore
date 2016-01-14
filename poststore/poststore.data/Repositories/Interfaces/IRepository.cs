using System.Collections.Generic;

namespace PostStore.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        T CreateNew();

        IEnumerable<T> All();

        void AddNew(T item);

        void RemoveById(int id);

        void Update(T item);
    }
}
