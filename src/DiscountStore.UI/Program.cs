using DiscountStore.Core;
using DiscountStore.Data;
using DiscountStore.Models;
using DiscountStore.UI.Pages;
using DiscountStore.UI.Pages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DiscountStore.UI
{
    static class Program
    {
        static void Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            using var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;
            Init.Run(provider);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services
                    .AddSingleton<IMainPage, MainPage>()
                    .AddSingleton<IViewCart, ViewCart>()
                    .AddSingleton<IAddToCart, AddToCart>()
                    .AddSingleton<IRemoveFromCart, RemoveFromCart>()
                    .AddSingleton<ICheckout, Checkout>()
                    .AddSingleton<IRepository<Discount>, DiscountRepository>()
                    .AddSingleton<IRepository<Product>, ProductsRepository>()
                    .AddSingleton<ICartService, CartService>()
                    .AddSingleton<IClearCart, ClearCart>()
                    );
        }
    }
}
