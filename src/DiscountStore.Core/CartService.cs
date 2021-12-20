using DiscountStore.Data;
using DiscountStore.Models;
using System;
using System.Collections.Generic;

namespace DiscountStore.Core
{
    public class CartService : ICartService
    {
        private Dictionary<string, CartItem> _cart;

        public CartService()
        {
            _cart = new Dictionary<string, CartItem>();
        }
        public void AddItem(Product product)
        {
            int DEFAULTQUANTITY = 1;
            var cartItem = new CartItem(product.SKU, DEFAULTQUANTITY, product.Price);
            if (_cart.ContainsKey(cartItem.SKU))
            {
                _cart[cartItem.SKU].Quantity++;
                return;
            }
            _cart.Add(cartItem.SKU, cartItem);
        }

        public void RemoveItem(CartItem cartItem)
        {
            if (!_cart.ContainsKey(cartItem.SKU))
            {
                return;
            }
            if (_cart[cartItem.SKU].Quantity > 0)
            {
                _cart[cartItem.SKU].Quantity--;
                if (_cart[cartItem.SKU].Quantity < 1)
                {
                    _cart.Remove(cartItem.SKU);
                }
            }
        }

        public Dictionary<string, CartItem> ReviewCart()
        {
            return _cart;
        }
        public void EmptyCart()
        {
            _cart.Clear();
        }

        public decimal GetTotal()
        {
            decimal total = 0;
            if (_cart.Count < 1)
            {
                return total;
            }
            var discounts = new DiscountRepository().GetAll().ToDiscountDictionary();
            foreach (var item in _cart)
            {
                if (discounts.ContainsKey(item.Key) && discounts[item.Key].Quantity <= item.Value.Quantity)
                {
                    total += Utils.ApplyDiscount(discounts[item.Key], item.Value);
                    continue;
                }
                total += item.Value.Quantity * item.Value.ProductPrice;
            }
            return total;
        }
    }
}
