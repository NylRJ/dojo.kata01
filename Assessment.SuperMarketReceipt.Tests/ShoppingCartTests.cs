using Assessment.SuperMarketReceipt.model;
using Xunit;

namespace Assessment.SuperMarketReceipt.Tests
{
    public class ShoppingCartTests
    {
        [Fact]
        public void deveAdicionarProduto()
        {
            var cart = new Cart();
            var product = new Product("Apple", 2);
            cart.AddItem(product, 1);
            cart.AddItem(product, 1);
            Assert.Equal(1, cart.products.Count);
            Assert.Equal(2, cart.products[product]);

        }



        [Fact]
        public void deveTerPelomenosUmProdutoDuranteCheckout()
        {
            var cart = new Cart();
            var product = new Product("Apple", 2);
            cart.AddItem(product, 2);

            Assert.Equal(4, cart.Total);


        }



        [Fact]
        public void deveSerCapazDeEmitireReciboDePreco()
        {
            var cart = new Cart();
            var product = new Product("Apple", 2);
            cart.AddItem(product, 2);

            Assert.Equal(@"Apple 2 * 2 = 4 Total: 4", Receipt.Print(cart));

        }

        [Fact(Skip = "Not Implemented")]
        public void deveSerCapazDeEmitireReciboDePrecoComDesconto()
        {
            var cart = new Cart();
            var product = new Product("Apple", 2);
            cart.AddItem(product, 2);

            Assert.Equal(@"Apple 2 * 2 = 4 Apple -50% -2 Total: 4", Receipt.Print(cart));

        }

    }
}
