using System.Collections.Generic;

namespace DiscountStore.Data
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}