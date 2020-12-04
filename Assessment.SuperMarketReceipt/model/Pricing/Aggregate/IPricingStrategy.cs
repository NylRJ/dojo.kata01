using Assessment.SuperMarketReceipt.model.order.OrderAggregate;

namespace Assessment.SuperMarketReceipt.model.Pricing.Aggregate
{
    public interface IPricingStrategy
    {
        Price GetTotal(IOrderItemContext item);
    }
}
