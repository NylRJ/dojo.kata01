using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment.SuperMarketReceipt.model
{
    public class Receipt
    {
        public decimal Total { get; set; }

        public static string Print(Cart cart)
        {
            var builder = new StringBuilder();
            foreach (var (p, q) in cart.Products)
            {
                builder.AppendLine($"{p.Name} {q} * {p.Price} = {q * p.Price}");
            }

            builder.AppendLine($"Total: {cart.Total}");
            return builder.ToString();
        }
    }
}
