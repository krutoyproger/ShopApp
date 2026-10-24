using System.Collections.Generic;
using task2;

namespace Core
{
    public interface IRepository<T> where T : class, IPrimary
    {
        void Add(T item);
        T GetById(int id);
        IReadOnlyList<T> GetAll();
        bool Update(T item);
        bool Delete(int id);
    }
}

