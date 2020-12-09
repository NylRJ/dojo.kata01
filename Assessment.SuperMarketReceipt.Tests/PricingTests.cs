using System;

using NSubstitute;
using Assessment.SuperMarketReceipt.model.Pricing.Aggregate;
using Assessment.SuperMarketReceipt.model.order.OrderAggregate;
using Xunit;

namespace Assessment.SuperMarketReceipt.Tests
{

    public class PricingTests
    {
        [Theory]
        [InlineData(0, 10.00, 0.00)]
        [InlineData(10, 0.00, 0.00)]
        [InlineData(1, 10.00, 10.00)]
        [InlineData(10, 1.00, 10.00)]
        [InlineData(20, 10.00, 200.00)]
        public void deveRetornarPrecoTotalDasUnidadesMultiplicadasPeloPrecoUnitario(int units, decimal unitPrice, decimal expectedTotalPrice)
        {
            //Arrange
            var regularPricingStrategy = new RegularPricingStrategy();
            var orderItem = Substitute.For<IOrderItemContext>();
            orderItem.GetUnits().Returns(units);
            orderItem.GetUnitPrice().Returns(unitPrice);

            //Act
            var totalPrice = regularPricingStrategy.GetTotal(orderItem);

            //Assert
            Assert.Equal(expectedTotalPrice, totalPrice);
        }

        [Theory]
        [InlineData(0, 1.00)]
        [InlineData(-1, 1.00)]
        public void deveLancaExecaoSeLimiteDeVolumeEmenosDoQueUm(int volumeThreshold, decimal unitPrice)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new VolumePricingStrategy(volumeThreshold, unitPrice));
        }

        [Fact]
        public void deveLancaExecaoSePrecoForNulo()
        {
        
            Assert.Throws<ArgumentOutOfRangeException>(() => new VolumePricingStrategy(Arg.Any<int>(),null ));
        }

        [Theory]
        [InlineData(3, 130.00, 2, 50.00, 100.00)]
        [InlineData(3, 130.00, 3, 50.00, 130.00)]
        [InlineData(3, 130.00, 4, 50.00, 180.00)]
        [InlineData(3, 130.00, 5, 50.00, 230.00)]
        [InlineData(2, 45.00, 1, 30.00, 30.00)]
        [InlineData(2, 45.00, 2, 30.00, 45.00)]
        [InlineData(2, 45.00, 3, 30.00, 75.00)]
        public void DeveAplicarDescontoSeAplicavel(int volumeThreshold, decimal volumePrice, int units, decimal unitPrice, decimal expectedTotalPrice)
        {
            //Arrange
            var volumePricingStrategy = new VolumePricingStrategy(volumeThreshold, volumePrice);

            var orderItem = Substitute.For<IOrderItemContext>();
            orderItem.GetUnits().Returns(units);
            orderItem.GetUnitPrice().Returns(unitPrice);

            //Act
            var totalPrice = volumePricingStrategy.GetTotal(orderItem);

            //Assert
            Assert.Equal(expectedTotalPrice, totalPrice);
        }


        [Theory]
        [InlineData(0.00, 10.00, 0.00)]
        [InlineData(10.00, 0.00, 0.00)]
        [InlineData(10.00, 10.00, 10.00)]
        [InlineData(10.00, 20.00, 10.00)]
        public void DeveRetornarOMenorPrecoTotal(decimal totalPrice1, decimal totalPrice2, decimal expectedTotalPrice)
        {
            //Arrange
            var compositeLowestPricingStrategy = new CompositeLowestPricingStrategy();

            var orderItem = Substitute.For<IOrderItemContext>();

            var pricingStrategy1 = Substitute.For<IPricingStrategy>();
            pricingStrategy1.GetTotal(orderItem).Returns(totalPrice1);

            var pricingStrategy2 = Substitute.For<IPricingStrategy>();
            pricingStrategy2.GetTotal(orderItem).Returns(totalPrice2);

            compositeLowestPricingStrategy.AddPricingStrategy(pricingStrategy1);
            compositeLowestPricingStrategy.AddPricingStrategy(pricingStrategy2);

            //Act
            var totalPrice = compositeLowestPricingStrategy.GetTotal(orderItem);

            //Assert
            Assert.Equal(expectedTotalPrice, totalPrice);
        }

        
    }
}
