using System;

namespace Assessment.SuperMarketReceipt.model
{
    public class Product
    {

        public Product(string name, decimal price)
        {

            if (price < 0)
            {
                throw new ArgumentException(nameof(price));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }
            this.Price = price;

            this.Name = name;
        }

        public decimal Price { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Price == product.Price &&
                   Name == product.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Price, Name);
        }
    }
}
