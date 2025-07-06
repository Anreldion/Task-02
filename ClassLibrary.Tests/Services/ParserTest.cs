using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager.Core.Services;
using ProductManager.Tests.Shared;
using System.Collections.Generic;
using System.Text.Json;
using ProductManager.Core.Products;
using System.Linq;
using System.Text.Json.Serialization;

namespace ProductManager.Tests.Parsers
{
    [TestClass]
    public class ParserTests
    {
        private Parser _parser;

        [TestInitialize]
        public void Setup()
        {
            _parser = new Parser();
        }

        [TestMethod]
        public void Serialize_ValidProducts_ShouldReturnJson()
        {
            // Arrange
            IEnumerable<Product> products = new List<Product> { TestData.Standard, TestData.QuantityTwo };

            // Act
            string json = _parser.Serialize(products);

            // Assert
            Assert.IsFalse(string.IsNullOrWhiteSpace(json));
            Assert.IsTrue(json.Contains("Standard"));
            Assert.IsTrue(json.Contains("PurchasePrice"));
        }

        [TestMethod]
        public void Serialize_NullInput_ShouldThrow()
        {
            // Act & Assert
            Assert.ThrowsException<System.ArgumentNullException>(() =>
            {
                _parser.Serialize(null);
            });
        }

        [TestMethod]
        public void Deserialize_ValidJson_ShouldReturnProducts()
        {
            // Arrange
            var original = new List<Product> { TestData.Standard };
            var json = JsonSerializer.Serialize(original, new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new JsonStringEnumConverter() }
            });

            // Act
            var result = _parser.Deserialize(json).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Standard", result[0].Name);
            Assert.AreEqual(10m, result[0].PurchasePrice);
        }

        [TestMethod]
        public void Deserialize_EmptyInput_ShouldReturnEmptyList()
        {
            // Act
            var result = _parser.Deserialize("").ToList();

            // Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}
