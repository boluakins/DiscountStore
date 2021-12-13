using DiscountStore.Models;
using System.Collections.Generic;

namespace DiscountStore.Data
{
    public class DiscountRepository : IRepository<Discount>
    {
        //public IEnumerable<Discount> DbSet { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public IEnumerable<Discount> GetAll()
        {
            return new List<Discount>
            {
                new Discount("Big Mug", 2, (decimal)1.5),
                new Discount("Napkins Pack", 3, (decimal)0.9),
            };
        }
    }
}
