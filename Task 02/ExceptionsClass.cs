using System;

namespace ClassLibrary
{
    //****************************************************************
    // 12. В случае невозможности выполнения какой-либо операции
    // сгенерировать соответствующее исключение (желательно, собственное)
    //****************************************************************

    public class ProductArgumentException : ArgumentException
    {
        public int Value { get; }
        public ProductArgumentException(string message, int val) : base(message)
        {
            Value = val;
        }
    }
    public class ProductExceptions : Exception
    {
        public ProductExceptions(string message) : base(message)
        {
        }
    }
    public class JSONExceptions : Exception
    {
        public JSONExceptions(string message) : base(message)
        {
        }
    }
}
