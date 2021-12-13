﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountStore.Models
{
    public class Discount
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public Discount(string sku, int quantity, decimal price)
        {
            SKU = sku;
            Quantity = quantity;
            Price = price;
        }
    }
}