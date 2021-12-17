using DiscountStore.Data;
using DiscountStore.Models;
using System;
using System.Collections.Generic;

namespace DiscountStore.Core
{
    public class CartService
    {
        private Dictionary<string, CartItem> cart;
        public CartService()
        {
            cart = new Dictionary<string, CartItem>();
        }
        public void AddItem(Product product)
        {
            int DEFAULTQUANTITY = 1;
            var cartItem = new CartItem(product.SKU, DEFAULTQUANTITY, product.Price);
            if (!cart.ContainsKey(cartItem.SKU))
            {
                cart.Add(cartItem.SKU, cartItem);
            }
            cart[product.SKU].Quantity++;
        }

        public void RemoveItem(Product product)
        {
            if (!cart.ContainsKey(product.SKU))
            {
                return;
            }
            if (cart[product.SKU].Quantity > 0)
            {
                cart[product.SKU].Quantity--;
            }
        }

        public Dictionary<string, CartItem> ReviewCart()
        {
            return cart;

        }
        public void EmptyCart()
        {
            cart.Clear();
        }

        public decimal GetTotal()
        {
            var discounts = new DiscountRepository().GetAll().ToDiscountDictionary();
            decimal total = 0;
            foreach (var item in cart)
            {
                if (discounts.ContainsKey(item.Key) && discounts[item.Key].Quantity <= item.Value.Quantity)
                {
                    total += Utils.ApplyDiscount(discounts[item.Key], item.Value);
                }
                total += item.Value.Quantity * item.Value.ProductPrice;
            }

            return total;
        }
    }
}
