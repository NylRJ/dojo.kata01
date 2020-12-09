using Assessment.SuperMarketReceipt.domain;

namespace SupermarketReceipt.Repository
{
    public interface SupermarketCatalog
    {
        void AddProduct(Product product, double price);

        double GetUnitPrice(Product product);
    }
}
