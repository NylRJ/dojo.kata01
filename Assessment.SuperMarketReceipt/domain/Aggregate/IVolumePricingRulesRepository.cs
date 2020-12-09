using System;

namespace Assessment.SuperMarketReceipt.domain.Aggregate
{
    public interface IVolumePricingRulesRepository
    {
        VolumePricingRule GetByProductId(Guid productId);
    }
}
