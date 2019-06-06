using System.Collections.Generic;

namespace Hotel.BLL.Interfaces
{
    public interface IService<T>
    {
        T Get(int id);

        IEnumerable<T> GetAll();

        void Create(T item);

        void Update(T item);

        void Delete(int id);
    }
}
