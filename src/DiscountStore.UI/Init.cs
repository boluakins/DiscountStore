using DiscountStore.UI.Pages;
using DiscountStore.UI.Pages.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace DiscountStore.UI
{
    static class Init
    {
        public static void Run(IServiceProvider provider)
        {
            var mainpage = provider.GetRequiredService<IMainPage>();
            mainpage.View();

        }

    }
}
