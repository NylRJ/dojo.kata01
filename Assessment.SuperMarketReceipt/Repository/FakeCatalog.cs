using System.Collections.Generic;
using Assessment.SuperMarketReceipt.domain;

namespace SupermarketReceipt.Repository
{
    public class FakeCatalog : SupermarketCatalog
    {
        private readonly IDictionary<string, double> _prices = new Dictionary<string, double>();
        private readonly IDictionary<string, Product> _products = new Dictionary<string, Product>();

        public void AddProduct(Product product, double price)
        {
            if (price <= 0.0) {
                throw new System.Exception("Fala ao adicionar produto");
            }
            _products.Add(product.Name, product);
            _prices.Add(product.Name, price);
        }

        public double GetUnitPrice(Product product)
        {//Refatorado
            return _prices[product.Name];
        }
    }
}
