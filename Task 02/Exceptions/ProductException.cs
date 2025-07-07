using System;

namespace ProductManager.Core.Exceptions
{
    /// <summary>
    /// Represents an error related to product operations.
    /// </summary>
    public class ProductException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductException"/> class.
        /// </summary>
        public ProductException() { }

        /// <summary>
        /// Initializes a new instance with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ProductException(string message)
            : base(message) { }

        /// <summary>
        /// Initializes a new instance with a specified error message and a reference to the inner exception.
        /// </summary>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">The inner exception.</param>
        public ProductException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
