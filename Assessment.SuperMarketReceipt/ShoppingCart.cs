using Assessment.SuperMarketReceipt.domain;
using SupermarketReceipt.Repository;
using SupermarketReceipt.Strategy;
using System;
using System.Collections.Generic;

namespace Assessment.SuperMarketReceipt
{
    public class ShoppingCart
    {
        private readonly List<ProductQuantity> _items = new List<ProductQuantity>();
        private readonly Dictionary<Product, double> _productQuantities = new Dictionary<Product, double>();


        public List<ProductQuantity> GetItems()
        {
            return new List<ProductQuantity>(_items);
        }

        //Refatorado
        public void AddItem(Product product, double quantity = 1.0)
        {
            _items.Add(new ProductQuantity(product, quantity));
            if (_productQuantities.ContainsKey(product))
            {
                var newAmount = _productQuantities[product] + quantity;
                _productQuantities[product] = newAmount;
            }
            else
            {
                _productQuantities.Add(product, quantity);
            }
        }

        //Refatorado
        public void HandleOffers(Receipt receipt, Dictionary<Product, Offer> offers, SupermarketCatalog catalog)
        {
            Discount discount = null;

            foreach (var product in _productQuantities.Keys)
            {
                var quantity = _productQuantities[product];
                var offerStrategy = new OfferStrategy(offers);

                var strategy = offerStrategy.getStrategyFor(product, quantity, catalog);
                if (strategy != null)
                    discount = strategy.applyStrategy();

                if (discount != null)
                {
                    receipt.AddDiscount(discount);
                }

            }
        }
    }
}
