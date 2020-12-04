using System;
using Assessment.SuperMarketReceipt.model.Pricing.Aggregate;
using Assessment.SuperMarketReceipt.model.valueObject;

namespace Assessment.SuperMarketReceipt.model.order.OrderAggregate
{
    public class OrderItem : Entity<Guid>, IOrderItemContext
    {
        public Guid ProductId { get; }

        private readonly IPricingStrategy _pricingStrategy;

        private readonly Price _unitPrice;
        private int _units;

        public OrderItem(Guid id, Guid productId, Price unitPrice, IPricingStrategy pricingStrategy, int units = 1) : base(id)
        {
            if (units < 1) { throw new ArgumentOutOfRangeException(nameof(units)); }
            if (unitPrice == null) { throw new ArgumentNullException(nameof(unitPrice)); }
            if (unitPrice.Value < 0) { throw new ArgumentOutOfRangeException(nameof(unitPrice)); }

            _pricingStrategy = pricingStrategy ?? throw new ArgumentNullException(nameof(pricingStrategy));

            ProductId = productId;

            _unitPrice = unitPrice;
            _units = units;
        }

        /// <summary>
        /// Obtém o número da unidade do produto OrderItem.
        /// </summary>
        /// <returns>A <see cref="int"/>.</returns>
        public int GetUnits()
        {
            return _units;
        }

        /// <summary>
        /// Obtém o preço unitário do produto OrderItem.
        /// </summary>
        /// <returns>A <see cref="Price"/> object</returns>
        public Price GetUnitPrice()
        {
            return _unitPrice;
        }

        /// <summary>
        /// Obtém o preço unitário do produto OrderItem.
        /// </summary>
        /// <returns>A <see cref="Price"/> object</returns>
        public Price GetTotalPrice()
        {
            return _pricingStrategy.GetTotal(this);
        }

        /// <summary>
        /// Adiciona <paramref name = "units" /> do produto existente no OrderItem.
        /// </summary>
        /// <param name="units"></param>
        public void AddUnits(int units)
        {
            if (units < 1) { throw new ArgumentOutOfRangeException(nameof(units)); }

            _units += units;
        }
    }
}
