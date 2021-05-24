using System.Collections.Generic;

namespace burgershack.Interfaces
{
    public interface IRepo<T>
    {
        IEnumerable<T> Get();
        T GetOne(int id);
        T Create(T data);
        bool Update(T data);
        bool Delete(int id);
    }
}