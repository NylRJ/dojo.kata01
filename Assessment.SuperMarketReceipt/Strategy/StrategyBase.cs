using System;
using System.Collections.Generic;
using System.Text;
using Assessment.SuperMarketReceipt.domain;

namespace SupermarketReceipt.Strategy
{
    public abstract class StrategyBase
    {

        public Discount Discount { get; set; } = null;
        public Double Quantity { get; set; }
        public Double UnitPrice { get; set; }
        public Product Product { get; set; }
        public Offer Offer { get; set; }


    }
}
