using System.Collections.Generic;
using Assessment.SuperMarketReceipt;
using Assessment.SuperMarketReceipt.domain;
using SupermarketReceipt.Repository;

namespace Assessment.SuperMarketReceipt
{
    public class Teller
    {
        private readonly SupermarketCatalog _catalog;
        private readonly Dictionary<Product, Offer> _offers = new Dictionary<Product, Offer>();

        public Teller(SupermarketCatalog catalog)
        {
            _catalog = catalog;
        }

        public void AddSpecialOffer(SpecialOfferType offerType, Product product, double argument)
        {
            _offers[product] = new Offer(offerType, product, argument);
        }

        //Refatc
        public Receipt ChecksOutArticlesFrom(ShoppingCart theCart)
        {
            var receipt = new Receipt();
            var productQuantities = theCart.GetItems();
            foreach (var productQuantity in productQuantities)
            {
                var unitPrice = _catalog.GetUnitPrice(productQuantity.Product);
                receipt.AddProduct(productQuantity, unitPrice);
            }

            theCart.HandleOffers(receipt, _offers, _catalog);

            return receipt;
        }
    }
}
