using System;

namespace Assessment.SuperMarketReceipt.domain.Aggregate
{
    public interface IPricingStrategyFactory
    {
        IPricingStrategy Create(Guid productId);
    }
}
