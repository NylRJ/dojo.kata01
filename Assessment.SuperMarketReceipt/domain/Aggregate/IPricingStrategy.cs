using Assessment.SuperMarketReceipt.model.order.OrderAggregate;

namespace Assessment.SuperMarketReceipt.domain.Aggregate
{
    public interface IPricingStrategy
    {
        Price GetTotal(IOrderItemContext item);
    }
}
