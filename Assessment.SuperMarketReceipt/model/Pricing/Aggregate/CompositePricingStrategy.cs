using System.Collections.Generic;
using Assessment.SuperMarketReceipt.model.order.OrderAggregate;

namespace Assessment.SuperMarketReceipt.model.Pricing.Aggregate
{
    public abstract class CompositePricingStrategy : IPricingStrategy
    {
        protected List<IPricingStrategy> PricingStrategies;

        protected CompositePricingStrategy()
        {
            PricingStrategies = new List<IPricingStrategy>();
        }

        public abstract Price GetTotal(IOrderItemContext item);

        public void AddPricingStrategy(IPricingStrategy pricingStrategy)
        {
            PricingStrategies.Add(pricingStrategy);
        }
    }
}
