using DiscountStore.Core;
using DiscountStore.UI.Pages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiscountStore.UI.Pages
{
    public class Checkout : ICheckout
    {
        private readonly ICartService _cartService;

        public Checkout(IServiceProvider provider)
        {
            _cartService = provider.GetRequiredService<ICartService>();
        }
        public void View()
        {
            Helpers.SetViewName("Get total");
            var total = _cartService.GetTotal();
            Console.WriteLine("Applying discounts where available...");
            Console.WriteLine($"Total cost: ${total}");
            Console.WriteLine();
        }
    }
}
