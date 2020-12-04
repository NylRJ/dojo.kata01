using System;

namespace Assessment.SuperMarketReceipt.model.Pricing.Aggregate
{
    public interface IPricingStrategyFactory
    {
        IPricingStrategy Create(Guid productId);
    }
}
