using System;
using System.Collections.Generic;
using System.Linq;
using Assessment.SuperMarketReceipt.model.order.OrderAggregate;
using Assessment.SuperMarketReceipt.model.Pricing.Aggregate;
using Assessment.SuperMarketReceipt.model.product;
using Assessment.SuperMarketReceipt.model.valueObject;

namespace Assessment.SuperMarketReceipt.model.order
{
    public class Order : Entity<Guid>, IAggregateRoot
    {

        private readonly List<OrderItem> _orderItems;
        private readonly IPricingStrategyFactory _pricingStrategyFactory;

        /// <summary>
        /// Obtém uma coleção somente leitura de <see cref = "OrderItem" /> do pedido atual.
        /// </summary>
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;


        /// <summary>
        /// Cria uma nova instância <see cref = "Order" />.
        /// </summary>
        public Order(Guid id, IPricingStrategyFactory pricingStrategyFactory) : base(id)
        {
            _pricingStrategyFactory = pricingStrategyFactory;
            _orderItems = new List<OrderItem>();
        }


        /// <summary>
        /// Adiciona um <see cref = "Product" /> ao OrderItem com um ou vários <paramref name = "units" />.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="units"></param>
        public void AddOrderItem(Product product, int units = 1)
        {
            var existingOrderForProduct = _orderItems.SingleOrDefault(o => o.ProductId == product.Id);

            if (existingOrderForProduct != null)
            {
                existingOrderForProduct.AddUnits(units);
            }
            else
            {
                var pricingStrategy = _pricingStrategyFactory.Create(product.Id);
                var orderItem = new OrderItem(Guid.NewGuid(), product.Id, product.UnitPrice, pricingStrategy, units);

                _orderItems.Add(orderItem);
            }
        }


        /// <summary>
        /// Obtém o preço total do pedido atual.
        /// </summary>
        /// <returns>A <see cref="Price"/> object</returns>
        public Price GetTotalPrice()
        {
            Price totalPrice = 0;

            foreach (var orderItem in _orderItems)
            {
                totalPrice = totalPrice + orderItem.GetTotalPrice();
            }

            return totalPrice;
        }
    }
}
