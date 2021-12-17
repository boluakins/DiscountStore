using DiscountStore.Models;
using System.Collections.Generic;

namespace DiscountStore.Core
{
    public static class Utils
    {
        public static Dictionary<string, Discount> ToDiscountDictionary(this IEnumerable<Discount> discounts)
        {
            var discountDictionary = new Dictionary<string, Discount>();
            foreach (var discount in discounts)
            {
                discountDictionary.Add(discount.SKU, discount);
            }
            return discountDictionary;
        }

        public static decimal ApplyDiscount(Discount discount, CartItem item)
        {
            return ((item.Quantity / discount.Quantity) * discount.Price)
                        + ((item.Quantity % discount.Quantity) * item.ProductPrice);
        }
    }
}
