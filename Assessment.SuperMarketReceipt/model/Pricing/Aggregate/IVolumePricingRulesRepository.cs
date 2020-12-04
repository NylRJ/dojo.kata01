using System;

namespace Assessment.SuperMarketReceipt.model.Pricing.Aggregate
{
    public interface IVolumePricingRulesRepository
    {
        VolumePricingRule GetByProductId(Guid productId);
    }
}
