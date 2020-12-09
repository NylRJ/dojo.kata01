using System.Globalization;
using Assessment.SuperMarketReceipt.model;

namespace Assessment.SuperMarketReceipt.domain
{
    public class Price : Money
    {
        /// <summary>
        /// Cria uma nova instância <see cref = "Price" />.
        /// </summary>
        /// <param name="value"></param>
        public Price(decimal value) : base(value)
        {
        }

        public static Price operator +(Price left, Price right)
        {
            return new Price(left.Value + right.Value);
        }

        public static Price operator -(Price left, Price right)
        {
            return new Price(left.Value - right.Value);
        }

        public static Price operator *(int left, Price right)
        {
            return new Price(left * right.Value);
        }

        public static bool operator <(Price left, Price right)
        {
            return left.Value < right.Value;
        }

        public static bool operator >(Price left, Price right)
        {
            return left.Value > right.Value;
        }

        public static implicit operator Price(decimal value)
        {
            return new Price(value);
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
