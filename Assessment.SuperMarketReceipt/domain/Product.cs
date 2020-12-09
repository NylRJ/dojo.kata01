using System.Collections.Generic;

namespace Assessment.SuperMarketReceipt.domain
{
    public class Product
    {
        public Product(string name, ProductUnit unit)
        {
            Name = name;
            Unit = unit;
        }

        public string Name { get; }
        public ProductUnit Unit { get; }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null &&
                   Name == product.Name &&
                   Unit == product.Unit;
        }

        public override int GetHashCode()
        {
            var hashCode = -2006139537;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Unit.GetHashCode();
            return hashCode;
        }
    }

    public class ProductQuantity
    {
        public ProductQuantity(Product product, double quantity)
        {//Refatorado
            Product = product;
            Quantity = quantity;
        }

        public Product Product { get; }
        public double Quantity { get; }
    }

    public enum ProductUnit
    {
        Kilo,
        Each
    }
}
