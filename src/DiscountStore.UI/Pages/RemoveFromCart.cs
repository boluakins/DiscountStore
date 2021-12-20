using DiscountStore.Core;
using DiscountStore.UI.Pages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DiscountStore.UI.Pages
{
    public class RemoveFromCart : IRemoveFromCart
    {
        private readonly ICartService _cartService;

        public RemoveFromCart(IServiceProvider provider)
        {
            _cartService = provider.GetRequiredService<ICartService>();

        }
        public void View()
        {
            Helpers.SetViewName("Remove from cart");
            var items = _cartService.ReviewCart();
            if (items.Count < 1)
            {
                Console.WriteLine("cart is empty");
                return;
            }
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key}    :    number of items - {item.Value.Quantity}");
            }
            Console.WriteLine();
            Console.WriteLine("enter product to remove (name)");
            var valid = false;
            while (!valid)
            {
                Console.WriteLine();
                var choice = Console.ReadLine();
                var p = items.FirstOrDefault(p => p.Value.SKU.Equals(choice, StringComparison.OrdinalIgnoreCase));
                if (p.Value is null)
                {
                    Console.WriteLine();
                    Console.WriteLine("enter valid product name");
                    Console.WriteLine();
                    continue;
                }
                _cartService.RemoveItem(p.Value);
                Console.WriteLine("product removed successfully");
                Console.WriteLine();
                valid = true;
            }

        }
    }
}
