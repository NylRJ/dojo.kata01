using System;
using System.Collections.Generic;
using System.Text;
using Assessment.SuperMarketReceipt.domain;
using SupermarketReceipt.Repository;

namespace SupermarketReceipt.Strategy
{
    public class OfferStrategy
    {
        public Dictionary<Product, Offer> Offers { get; set; }

        public OfferStrategy(Dictionary<Product, Offer> offers)
        {
            this.Offers = offers;
        }
        public IOfferStrategy getStrategyFor(Product product, Double quantity, SupermarketCatalog catalog)
        {
            var unitPrice = catalog.GetUnitPrice(product);

            if (Offers.ContainsKey(product))
            {
                switch (Offers[product].OfferType)
                {
                    case SpecialOfferType.ThreeForTwo:
                        return new ThreeForTwoStrategy(quantity, unitPrice, product);

                    case SpecialOfferType.TwoForAmount:
                        return new TwoForAmountStrategy(quantity, unitPrice, product, Offers[product]);

                    case SpecialOfferType.TenPercentDiscount:
                        return new TenPercentDiscountStrategy(quantity, unitPrice, product, Offers[product]);

                    case SpecialOfferType.FiveForAmount:
                        return new FiveForAmountConcreto(quantity, unitPrice, product, Offers[product]);

                    default:
                        return null;
                }
            }

            return null;
        }
    }
}
