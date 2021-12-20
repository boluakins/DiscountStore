using DiscountStore.Core;
using DiscountStore.Data;
using DiscountStore.Models;
using DiscountStore.UI.Pages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DiscountStore.UI.Pages
{
    public class AddToCart : IAddToCart
    {
        private readonly ICartService _cartService;
        private readonly IRepository<Product> _productRepo;

        public AddToCart(IServiceProvider provider)
        {
            _cartService = provider.GetRequiredService<ICartService>();
            _productRepo = provider.GetRequiredService<IRepository<Product>>();
        }
        public void View()
        {
            Helpers.SetViewName("Add item to cart");
            var products = _productRepo.GetAll();
            if (products.Count() < 1)
            {
                Console.WriteLine("no products available");
                return;
            }
            foreach (var product in products)
            {
                Console.WriteLine($"{product.SKU}    :    $ {product.Price}");
            }
            Console.WriteLine();
            Console.WriteLine("enter product to add (name)");
            var valid = false;
            while (!valid)
            {
                Console.WriteLine();
                var choice = Console.ReadLine();
                var p = products.FirstOrDefault(p => p.SKU.Equals(choice, StringComparison.OrdinalIgnoreCase));
                if (p is null)
                {
                    Console.WriteLine();
                    Console.WriteLine("enter valid product name");
                    Console.WriteLine();
                    continue;
                }
                _cartService.AddItem(p);
                Console.WriteLine("product added successfully");
                Console.WriteLine();
                valid = true;
            }
        }
    }
}
