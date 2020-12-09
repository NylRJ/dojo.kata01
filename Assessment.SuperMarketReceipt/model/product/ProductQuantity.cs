namespace Assessment.SuperMarketReceipt.model.product
{
   public class ProductQuantity
    {
        public ProductQuantity(Product product, double weight)
        {
            Product = product;
            Quantity = weight;
        }

        public Product Product { get; }
        public double Quantity { get; }
    }
}
