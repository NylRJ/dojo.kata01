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
    }
}
