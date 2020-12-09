using System;
using System.Collections.Generic;
using System.Text;
using Assessment.SuperMarketReceipt.domain;

namespace SupermarketReceipt.Strategy
{
    class TwoForAmountStrategy : StrategyBase, IOfferStrategy
    {

        public TwoForAmountStrategy(double quantity, double unitPrice, Product product, Offer offer)
        {
            this.Offer = offer;
            this.Product = product;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }

        public Discount applyStrategy()
        {
            var operand = 2;
            var quantityAsInt = (int)Quantity;
            if (quantityAsInt >= operand)
            {
                var total = Offer.OfferAmount * (quantityAsInt / operand) + quantityAsInt % 2 * UnitPrice;
                var discountN = UnitPrice * Quantity - total;
                Discount = new Discount(Product, "2 for " + Offer.OfferAmount, -discountN);
            }



            return Discount;
        }
    }
}
