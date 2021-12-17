using DiscountStore.Core;
using DiscountStore.Data;
using DiscountStore.Models;
using System;
using System.Linq;

namespace DiscountStore.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }

        static void Init()
        {
            var processor = new Processor();
            Console.WriteLine("Welcome");
            Console.WriteLine("");
            Console.WriteLine("Select an option:");
            Console.WriteLine("");
            Console.WriteLine("1: view products");
            Console.WriteLine("2: view cart");
            Console.WriteLine("3: add product to cart");
            Console.WriteLine("99: exit");
            Console.WriteLine();
            var option = Console.ReadLine();
            bool validResponse = false;
            while (!validResponse) 
            {
                switch (option)
                {
                    case "1":

                    default:
                        break;
                }
            }



                processor.CartService.AddItem(processor.Products.First());
            processor.CartService.AddItem(processor.Products.Last());
            processor.CartService.AddItem(processor.Products.First());


        }

        static void SelectOption(string option)
        {

        }
        static void ReviewCart()
        {
            var cartService = new CartService();
            var cart = cartService.ReviewCart();
            foreach (var item in cart)
            {
                Console.WriteLine($"{item.Key} : {item.Value.ProductPrice} : {item.Value.Quantity}");
            }
        }
    }
}
