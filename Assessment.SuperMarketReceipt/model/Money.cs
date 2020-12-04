using System;
using System.Collections.Generic;
using Assessment.SuperMarketReceipt.model.valueObject;


namespace Assessment.SuperMarketReceipt.model
{
    public class Money : ValueObject
    {
        /// <summary>
        /// Create a new <see cref="Money"/> instance.
        /// </summary>
        public Money(decimal value)
        {
            if (value < 0) { throw new ArgumentOutOfRangeException(nameof(value)); }

            Value = value;
        }

        public decimal Value { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
