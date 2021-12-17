using DiscountStore.Core;
using DiscountStore.Data;
using DiscountStore.Models;
using System.Collections.Generic;

namespace DiscountStore.UI
{
    public class Processor
    {
        public Processor()
        {
            Products = new ProductsRepository().GetAll();
            CartService = new CartService();
        }

        public IEnumerable<Product> Products { get; }
        public CartService CartService { get; }
    }
}
