using System.Collections.Generic;

namespace DiscountStore.Data
{
    public interface IRepository<T>
    {
        //IEnumerable<T> DbSet { get; set; }
        IEnumerable<T> GetAll();
    }
}