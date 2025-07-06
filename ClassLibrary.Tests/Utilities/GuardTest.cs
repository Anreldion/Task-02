using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager.Core.Utilities;

namespace ProductManager.Tests.Utilities
{
    [TestClass]
    public class GuardTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNull_ThrowsException_WhenValueIsNull()
        {
            string value = null;
            Guard.NotNull(value, nameof(value));
        }

        [TestMethod]
        public void NotNull_DoesNotThrow_WhenValueIsNotNull()
        {
            // Arrange
            const string value = "notNull";

            // Act & Assert
            Guard.NotNull(value, nameof(value));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NotEmpty_ThrowsException_WhenValueIsEmpty()
        {
            var value = string.Empty;
            Guard.NotEmpty(value, nameof(value));
        }

        [TestMethod]
        public void NotEmpty_DoesNotThrow_WhenValueIsValid()
        {
            const string value = "notEmpty";
            Guard.NotEmpty(value, nameof(value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AgainstNegative_ThrowsException_WhenValueIsNegative()
        {
            const int value = -1;
            Guard.AgainstNegative(value, nameof(value));
        }

        [TestMethod]
        public void AgainstNegative_DoesNotThrow_WhenValueIsPositive()
        {
            const int value = 1;
            Guard.AgainstNegative(value, nameof(value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AgainstZero_ThrowsException_WhenValueIsZero()
        {
            const int value = 0;
            Guard.AgainstZero(value, nameof(value));
        }

        [TestMethod]
        public void AgainstZero_DoesNotThrow_WhenValueIsPositive()
        {
            const int value = 1;
            Guard.AgainstZero(value, nameof(value));
        }
    }
}
