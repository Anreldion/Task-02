using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager.Core.Products;
using ProductManager.Core.Services;
using ProductManager.Tests.Shared;

namespace ProductManager.Tests.Services
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
            var products = new List<Product> { TestData.Standard, TestData.QuantityTwo };
            var json = _parser.Serialize(products);

            Assert.IsFalse(string.IsNullOrWhiteSpace(json));
            Assert.IsTrue(json.Contains("Standard"));
            Assert.IsTrue(json.Contains("$type"));
        }

        [TestMethod]
        public void Serialize_NullInput_ShouldThrow()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
            {
                _parser.Serialize(null);
            });
        }

        [TestMethod]
        public void Deserialize_ValidJson_ShouldReturnProducts()
        {
            var original = new List<Product> { TestData.Standard };
            var json = _parser.Serialize(original);

            var result = _parser.Deserialize(json).ToList();

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Standard", result[0].Name);
            Assert.AreEqual(10m, result[0].PurchasePrice);
        }

        [TestMethod]
        public void Deserialize_EmptyInput_ShouldReturnEmptyList()
        {
            var result = _parser.Deserialize("").ToList();
            Assert.AreEqual(0, result.Count);
        }
    }
}