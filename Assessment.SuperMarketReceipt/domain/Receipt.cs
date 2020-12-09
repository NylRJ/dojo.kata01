using System.Collections.Generic;

namespace Assessment.SuperMarketReceipt.domain
{
    public class Receipt
    {
        private readonly List<Discount> _discounts = new List<Discount>();
        private readonly List<ReceiptItem> _items = new List<ReceiptItem>();

        public double GetTotalPrice()
        {
            var total = 0.0;
            foreach (var item in _items) total += item.TotalPrice;
            foreach (var discount in _discounts) total += discount.DiscountAmount;
            return total;
        }
        
        public void AddProduct(ProductQuantity productQuantity, double unitPrice)
        {//Refatorado 
            var product = productQuantity.Product;
            var quantity = productQuantity.Quantity;
            var totalPrice = quantity * unitPrice;
            _items.Add(new ReceiptItem(product, quantity, unitPrice, totalPrice));
        }

        public List<ReceiptItem> GetItems()
        {
            return new List<ReceiptItem>(_items);
        }

        public void AddDiscount(Discount discount)
        {
            _discounts.Add(discount);
        }

        public List<Discount> GetDiscounts()
        {
            return _discounts;
        }
    }

    public class ReceiptItem
    {
        public ReceiptItem(Product product, double quantity, double price, double totalPrice)
        {//Refatorado
            Product = product;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
        }

        public Product Product { get; }
        public double Price { get; }
        public double TotalPrice { get; }
        public double Quantity { get; }
    }
}
