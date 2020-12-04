using System.Collections.Generic;
using System.Linq;

namespace Assessment.SuperMarketReceipt.model
{
    public class Cart
    {
        public Dictionary<Product, int> products { get; } = new Dictionary<Product, int>();

        public void AddItem(Product product, int quantity)
        {
            if (products.ContainsKey(product))
            {
                products[product] += quantity;
                return;
            }
            products.Add(product, quantity);

        }

        public decimal Checkout()
        {
            return products.Sum(c => c.Key.Price * c.Value);
        }
    }
}
