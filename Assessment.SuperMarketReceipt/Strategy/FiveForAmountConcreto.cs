using System;
using System.Collections.Generic;
using System.Text;
using Assessment.SuperMarketReceipt.domain;

namespace SupermarketReceipt.Strategy
{
    class FiveForAmountConcreto : StrategyBase, IOfferStrategy
    {
        public FiveForAmountConcreto(double quantity, double unitPrice, Product product, Offer offer)
        {
            this.Offer = offer;
            this.Product = product;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }


        public Discount applyStrategy()
        {
            var quantityAsInt = (int)Quantity;
            var operand = 5;
            var numberOfXs = quantityAsInt / operand;

            if (quantityAsInt >= operand)
            {
                var discountTotal = UnitPrice * Quantity - (Offer.OfferAmount * numberOfXs + quantityAsInt % 5 * UnitPrice);
                Discount = new Discount(Product, operand + " for " + Offer.OfferAmount, -discountTotal);
            }

            return Discount;
        }
    }
}
