using System;

namespace ProductManager.Core
{
    public class ProductArgumentException : ArgumentException
    {
        public int Value { get; }
        public ProductArgumentException(string message, int val) : base(message)
        {
            Value = val;
        }
    }
    public class ProductException : Exception
    {
        public ProductException(string message) : base(message)
        {
        }
    }
}
