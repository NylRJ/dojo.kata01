using System;
using System.Collections.Generic;
using System.Text;
using Assessment.SuperMarketReceipt.domain;

namespace SupermarketReceipt.Strategy
{
    public interface IOfferStrategy
    {
        Discount applyStrategy();
    }
}
