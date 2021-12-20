using DiscountStore.Core;
using DiscountStore.Data;
using DiscountStore.Models;
using DiscountStore.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DiscountStore.UI.Pages
{
    public class ClearCart : IClearCart
    {
        private readonly ICartService _cartService;

        public ClearCart(IServiceProvider provider)
        {
            _cartService = provider.GetRequiredService<ICartService>();
        }
        public void View()
        {
            _cartService.EmptyCart();
            Console.WriteLine("Cart Cleared Successfully");
            Console.WriteLine();
        }
    }
}