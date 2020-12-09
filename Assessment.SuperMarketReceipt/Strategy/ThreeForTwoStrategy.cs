using System;
using System.Collections.Generic;
using System.Text;
using Assessment.SuperMarketReceipt.domain;

namespace SupermarketReceipt.Strategy
{
    public class ThreeForTwoStrategy : StrategyBase, IOfferStrategy
    {
        public ThreeForTwoStrategy(double quantity, double unitPrice, Product product)
        {
            
            this.Product = product;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }

        public Discount applyStrategy()
        {

            var operand = ((int) Quantity) / 3;
            if (Quantity >= 3)
            {
                var discountAmount = Quantity * UnitPrice - (operand * 2 * UnitPrice + ((int)Quantity) % 3 * UnitPrice);
                this.Discount = new Discount(Product, "3 for 2", -discountAmount);
            }


            return Discount;
        }

        
    }
}
