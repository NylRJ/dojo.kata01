using System;
using Assessment.SuperMarketReceipt.model.catalogo;
using Assessment.SuperMarketReceipt.model.product;

using Xunit;

namespace Assessment.SuperMarketReceipt.Tests
{
    public class ShoppingCartTests
    {
 

        [InlineData(false)]
        public void DeveVerificarQueProdutoEstaNoNaoConstNoCart(bool existe)
        {
            //Arrange
            SupermarketCatalog catalog = new FakeCatalog();
            var toothbrush = new Product(Guid.NewGuid(),"toothbrush",0.99m, ProductUnit.Each);
            catalog.AddProduct(toothbrush, 0.99);
            var apples = new Product("apples", ProductUnit.Kilo);

            catalog.AddProduct(apples, 1.99);

            var cart = new ShoppingCart();


            cart.AddItemQuantity(apples, 2.5);


            var teller = new Teller(catalog);
            teller.AddSpecialOffer(SpecialOfferType.TenPercentDiscount, toothbrush, 10.0);

            // ACT
            var receipt = teller.ChecksOutArticlesFrom(cart);


            //Assert
            Assert.Equal(existe, cart.IsExiste(new ProductQuantity(toothbrush, 1)));

        }

    }
}
