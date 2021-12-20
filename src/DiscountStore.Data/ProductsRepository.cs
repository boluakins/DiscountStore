using DiscountStore.Models;
using System.Collections.Generic;

namespace DiscountStore.Data
{
    public class ProductsRepository : IRepository<Product>
    {
        public IEnumerable<Product> GetAll()
        {
            return new List<Product>
            {
                new Product("Vase", (decimal)1.20),
                new Product("Big Mug", (decimal)1.00),
                new Product("Napkins Pack", (decimal)0.45),
            };
        }
    }
}
