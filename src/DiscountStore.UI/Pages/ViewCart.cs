using DiscountStore.Core;
using DiscountStore.UI.Pages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiscountStore.UI.Pages
{
    public class ViewCart : IViewCart
    {
        private readonly ICartService _cartService;

        public ViewCart(IServiceProvider provider)
        {
            _cartService = provider.GetRequiredService<ICartService>();
        }
        public void View()
        {
            Helpers.SetViewName("Cart");
            var cart = _cartService.ReviewCart();
            if (cart.Count < 1)
            {
                Console.WriteLine("cart is empty");
                return;
            }
            foreach (var item in cart)
            {
                Console.WriteLine($"{item.Value.SKU}    :    $ {item.Value.ProductPrice}     *     {item.Value.Quantity}");
            }
            Console.WriteLine();
        }
    }
}
