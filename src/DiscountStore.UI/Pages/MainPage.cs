using DiscountStore.UI.Pages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace DiscountStore.UI.Pages
{
    public class MainPage : IMainPage
    {
        private readonly IAddToCart _add;
        private readonly IViewCart _viewCart;
        private readonly IRemoveFromCart _removeFromCart;
        private readonly ICheckout _checkout;
        private readonly IClearCart _clearCart;

        public MainPage(IServiceProvider provider)
        {
            _add = provider.GetRequiredService<IAddToCart>();
            _viewCart = provider.GetRequiredService<IViewCart>();
            _removeFromCart = provider.GetRequiredService<IRemoveFromCart>();
            _checkout = provider.GetRequiredService<ICheckout>();
            _clearCart = provider.GetRequiredService<IClearCart>();
        }
        public void View()
        {
            Helpers.SetViewName("Menu");
            Console.WriteLine("1: View cart");
            Console.WriteLine("2: Add to cart");
            Console.WriteLine("3: Remove from cart");
            Console.WriteLine("4: Clear cart");
            Console.WriteLine("5: Get total");
            Console.WriteLine("99: Exit application");
            Console.WriteLine();
            var validAnswer = false;
            Console.WriteLine("Enter choice:");
            while (!validAnswer)
            {
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _viewCart.View();
                        Helpers.MenuPrompt();
                        break;
                    case "2":
                        _add.View();
                        Helpers.MenuPrompt();
                        break;
                    case "3":
                        _removeFromCart.View();
                        Helpers.MenuPrompt();
                        break;
                    case "4":
                        _clearCart.View();
                        Helpers.MenuPrompt();
                        break;
                    case "5":
                        _checkout.View();
                        Helpers.MenuPrompt();
                        break;
                    case "99":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please select a valid choice ");
                        break;
                }
            }
        }
    }
}
