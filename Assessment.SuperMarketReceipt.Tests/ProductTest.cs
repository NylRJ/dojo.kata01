using System;
using Assessment.SuperMarketReceipt.model;
using Xunit;

namespace Assessment.SuperMarketReceipt.Tests
{
    public class ProductTests
    {
        [Fact]
        public void naoDevePermitirPrecoNegativo()
        {


            Assert.Throws<ArgumentException>(() => new Product("Aple", -1));


        }

        [Fact]
        public void naoDevePermitirNomeVazio()
        {


            Assert.Throws<ArgumentException>(() => new Product("", 2));
            Assert.Throws<ArgumentException>(() => new Product(" ", 2));
            Assert.Throws<ArgumentException>(() => new Product(null, 2));


        }

        [Fact]
        public void deveCriarProduto()
        {


            new Product("Apple", 2);



        }


    }
}
