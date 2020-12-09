using System;
using System.Collections.Generic;
using Assessment.SuperMarketReceipt.domain;
using SupermarketReceipt.Repository;
using Xunit;

namespace Assessment.SuperMarketReceipt.Tests
{
    public class SupermarketTest
    {
        [Fact]
        public void TenPercentDiscount()
        {
            // ARRANGE
            SupermarketCatalog catalog = new FakeCatalog();
            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);
            var apples = new Product("apples", ProductUnit.Kilo);
            catalog.AddProduct(apples, 1.99);

            var cart = new ShoppingCart();
            cart.AddItem(apples, 2.5);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, toothbrush, 10.0);

            // ACT
            var receipt = teller.ChecksOutArticlesFrom(cart);

            // ASSERT
            Assert.Equal(4.975, receipt.GetTotalPrice());
            Assert.Equal(new List<Discount>(), receipt.GetDiscounts());
            Assert.Single(receipt.GetItems());
            var receiptItem = receipt.GetItems()[0];
            Assert.Equal(apples, receiptItem.Product);
            Assert.Equal(1.99, receiptItem.Price);
            Assert.Equal(2.5 * 1.99, receiptItem.TotalPrice);
            Assert.Equal(2.5, receiptItem.Quantity);
        }

        //Feitos pelo aluno:
        [Fact]
        public void FiveForAmountTests()
        {
            // ARRANGE
            SupermarketCatalog catalog = new FakeCatalog();
            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);
            
            var cart = new ShoppingCart();
            cart.AddItem(toothbrush, 7);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.FiveForAmount, toothbrush, 4.0);

            // ACT
            var receipt = teller.ChecksOutArticlesFrom(cart);

            // ASSERT
            Assert.Equal(5.98, receipt.GetTotalPrice());
            Assert.Single(receipt.GetItems());
            var receiptItem = receipt.GetItems()[0];
            Assert.Equal(toothbrush, receiptItem.Product);
            Assert.Equal(0.99, receiptItem.Price);
            Assert.Equal(7 * 0.99, receiptItem.TotalPrice);
            Assert.Equal(7.0, receiptItem.Quantity);
        }

        [Fact]
        public void ThreeForTwoTests()
        {
            // ARRANGE
            SupermarketCatalog catalog = new FakeCatalog();
            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);

            var cart = new ShoppingCart();
            cart.AddItem(toothbrush, 7);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.ThreeForTwo, toothbrush, 0);

            // ACT
            var receipt = teller.ChecksOutArticlesFrom(cart);

            // ASSERT
            Assert.Equal(4.95, receipt.GetTotalPrice());
            Assert.Single(receipt.GetItems());
            var receiptItem = receipt.GetItems()[0];
            Assert.Equal(toothbrush, receiptItem.Product);
            Assert.Equal(0.99, receiptItem.Price);
            Assert.Equal(7 * 0.99, receiptItem.TotalPrice);
            Assert.Equal(7.0, receiptItem.Quantity);
        }

        [Fact]
        public void ThreeForTwoNotApplyedTests()
        {
            // ARRANGE
            SupermarketCatalog catalog = new FakeCatalog();
            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);

            var cart = new ShoppingCart();
            cart.AddItem(toothbrush, 2);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.ThreeForTwo, toothbrush, 0);

            // ACT
            var receipt = teller.ChecksOutArticlesFrom(cart);

            // ASSERT
            Assert.Equal(1.98, receipt.GetTotalPrice());
            Assert.Single(receipt.GetItems());
            var receiptItem = receipt.GetItems()[0];
            Assert.Equal(toothbrush, receiptItem.Product);
            Assert.Equal(0.99, receiptItem.Price);
            Assert.Equal(2 * 0.99, receiptItem.TotalPrice);
            Assert.Equal(2.0, receiptItem.Quantity);
            Assert.Empty(receipt.GetDiscounts());
        }

        [Fact]
        public void TwoForAmountTests()
        {
            // ARRANGE
            SupermarketCatalog catalog = new FakeCatalog();
            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);

            var cart = new ShoppingCart();
            cart.AddItem(toothbrush, 7);

            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TwoForAmount, toothbrush, 1.0);

            // ACT
            var receipt = teller.ChecksOutArticlesFrom(cart);

            // ASSERT
            Assert.Equal(3.99, receipt.GetTotalPrice());
            Assert.Single(receipt.GetItems());
            var receiptItem = receipt.GetItems()[0];
            Assert.Equal(toothbrush, receiptItem.Product);
            Assert.Equal(0.99, receiptItem.Price);
            Assert.Equal(7 * 0.99, receiptItem.TotalPrice);
            Assert.Equal(7.0, receiptItem.Quantity);
        }

        [Fact]
        public void AddProductAndValueTests()
        {
            // ARRANGE
            SupermarketCatalog catalog = new FakeCatalog();
            var toothbrush = new Product("toothbrush", ProductUnit.Each);
            var apples = new Product("apple", ProductUnit.Kilo);

            // ACT
            catalog.AddProduct(apples, 10.0);

            // ASSERT
            Assert.Throws<Exception>(() => catalog.AddProduct(toothbrush, 0));
            Assert.Equal(10.0, catalog.GetUnitPrice(apples));
            
        }
    }
}
