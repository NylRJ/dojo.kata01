using System;
using System.Collections.Generic;
using System.Text;
using Assessment.SuperMarketReceipt.domain;

namespace SupermarketReceipt.Strategy
{
    class TenPercentDiscountStrategy : StrategyBase, IOfferStrategy
    {
        public TenPercentDiscountStrategy(double quantity, double unitPrice, Product product, Offer offer)
        {
            this.Offer = offer;
            this.Product = product;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }

       
        public Discount applyStrategy()
        {

            Discount = new Discount(Product, Offer.OfferAmount + "% off", -Quantity * UnitPrice * Offer.OfferAmount / 100.0);

            return Discount;
        }
    }
}
