namespace DiscountStore.Models
{
    public class Product
    {
        public string SKU { get; set; }
        public decimal Price { get; set; }

        public Product(string sku, decimal price)
        {
            SKU = sku;
            Price = price;
        }
    }
}
