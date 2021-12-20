using DiscountStore.Core;
using DiscountStore.Data;
using DiscountStore.Models;
using NUnit.Framework;

namespace Discounts.Tests
{
    [TestFixture]
    public class CartServiceTests
    {
        [Test]
        public void ShouldSuccessfullyAddItemToCart()
        {
            // arrange
            var cartService = new CartService();
            var product = new Product("ball", (decimal)4.60);
            var cartItem = new CartItem(product.SKU, 1, product.Price);

            // act
            cartService.AddItem(product);

            // assert
            var cartSize = cartService.ReviewCart().Count;
            Assert.That(cartSize == 1);

            var cartContent = cartService.ReviewCart()[cartItem.SKU];
            Assert.AreEqual(cartItem.SKU, cartContent.SKU);
            Assert.That(cartContent.Quantity == 1);
        }

        [Test]
        public void ShouldSuccessfullyAddItemToCartMoreThanOnce()
        {
            // arrange
            var cartService = new CartService();
            var product = new Product("ball", (decimal)4.60);
            var cartItem = new CartItem(product.SKU, 1, product.Price);

            // act
            cartService.AddItem(product);
            cartService.AddItem(product);
            cartService.AddItem(product);
            cartService.AddItem(product);

            // assert
            var cartSize = cartService.ReviewCart().Count;
            Assert.That(cartSize == 1);

            var cartContent = cartService.ReviewCart()[cartItem.SKU];
            Assert.AreEqual(cartItem.SKU, cartContent.SKU);
            Assert.That(cartContent.Quantity == 4);
        }

        [Test]
        public void ShouldSuccessfullyRemoveItemFromCart()
        {
            // arrange
            var cartService = new CartService();
            var product = new Product("ball", (decimal)4.60);
            var cartItem = new CartItem(product.SKU, 1, product.Price);
            cartService.AddItem(product);

            // act
            cartService.RemoveItem(cartItem);

            // assert
            var cartSize = cartService.ReviewCart().Count;
            Assert.That(cartSize == 0);
        }

        [Test]
        public void ShouldSuccessfullyRemoveItemFromCartMoreThanOnce()
        {
            // arrange
            var cartService = new CartService();
            var product = new Product("ball", (decimal)4.60);
            var cartItem = new CartItem(product.SKU, 1, product.Price);
            var repeat = 5;
            for (int i = 0; i < repeat; i++)
            {
                cartService.AddItem(product);
            }

            // act
            for (int i = 0; i < repeat; i++)
            {
                cartService.RemoveItem(cartItem);
            }

            // assert
            var cartSize = cartService.ReviewCart().Count;
            Assert.That(cartSize == 0);
        }

        [Test]
        public void ShouldSuccessfullyApplyDiscount()
        {
            // arrange
            var product = new Product("ball", (decimal)4.60);
            var cartItem = new CartItem(product.SKU, 3, product.Price);
            var discount = new Discount(cartItem.SKU, 3, 10);

            // act
            var result = Utils.ApplyDiscount(discount, cartItem);

            // assert
            Assert.AreEqual(10, result);
        }
    }
}