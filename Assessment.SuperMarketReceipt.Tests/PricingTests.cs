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
        public void RegularStrategy_TotalPrice_ReturnsUnitsMultipliedByUnitPrice(int units, decimal unitPrice, decimal expectedTotalPrice)
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

        
    }
}
