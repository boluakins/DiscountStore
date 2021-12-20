using DiscountStore.Models;
using System.Collections.Generic;

namespace DiscountStore.Core
{
    public interface ICartService
    {
        void AddItem(Product product);
        void EmptyCart();
        decimal GetTotal();
        void RemoveItem(CartItem item);
        Dictionary<string, CartItem> ReviewCart();
    }
}