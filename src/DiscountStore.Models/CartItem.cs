namespace DiscountStore.Models
{
    public class CartItem
    {
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }

        public CartItem(string sku, int quantity, decimal productPrice)
        {
            SKU = sku;
            Quantity = quantity;
            ProductPrice = productPrice;
        }


    }
}
