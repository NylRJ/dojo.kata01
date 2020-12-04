using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.SuperMarketReceipt.model
{
    public class Cart
    {
        public Dictionary<Product, int> products { get; } = new Dictionary<Product, int>();
        public IReadOnlyDictionary<Product, int> Products => products;
        public void AddItem(Product product, int quantity)
        {
            if (products.ContainsKey(product))
            {
                products[product] += quantity;
                return;
            }
            products.Add(product, quantity);

        }

        public decimal Total => products.Sum(c => c.Key.Price * c.Value);


    }
}
