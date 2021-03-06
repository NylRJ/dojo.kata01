﻿using Assessment.SuperMarketReceipt.model.order.OrderAggregate;

namespace Assessment.SuperMarketReceipt.model.Pricing.Aggregate
{
    public class RegularPricingStrategy : IPricingStrategy
    {
        public virtual Price GetTotal(IOrderItemContext item)
        {
            return item.GetUnits() * item.GetUnitPrice();
        }
    }
}
