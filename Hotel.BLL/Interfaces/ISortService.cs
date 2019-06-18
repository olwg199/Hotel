using System.Collections.Generic;

namespace Hotel.BLL.Interfaces
{
    public interface ISortService<T> where T : class, IDto
    {
        IEnumerable<T> GetAll(string sortBy);
    }
}