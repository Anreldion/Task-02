using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager.Core.Exceptions;
using ProductManager.Tests.Shared;
using System;

namespace ProductManager.Tests.Products;

[TestClass]
[TestSubject(typeof(ProductManager.Core.Products.Product))]
public class ProductTest
{
    [TestMethod]
    public void Constructor_ValidParameters_ShouldSetProperties()
    {
        var product = TestData.Standard;

        Assert.AreEqual("Standard", product.Name);
        Assert.AreEqual(10m, product.PurchasePrice);
        Assert.AreEqual(2m, product.Markup);
        Assert.AreEqual(3, product.Quantity);
        Assert.AreEqual(12m, product.GetUnitCost());
        Assert.AreEqual(36m, product.GetTotalCost());
    }

    [TestMethod]
    public void OperatorPlus_SameNameAndType_ShouldCombineCorrectly()
    {
        var p1 = new TestProduct("Item", 10m, 2m, 2);
        var p2 = new TestProduct("Item", 14m, 4m, 2);

        var result = p1 + p2;

        Assert.AreEqual("Item", result.Name);
        Assert.AreEqual(4, result.Quantity);

        const decimal expectedPrice = (10m * 2 + 14m * 2) / 4;
        const decimal expectedMarkup = (2m * 2 + 4m * 2) / 4;

        Assert.AreEqual(expectedPrice, result.PurchasePrice);
        Assert.AreEqual(expectedMarkup, result.Markup);
        Assert.AreEqual(15.0m, result.GetUnitCost());
        Assert.AreEqual(60.0m, result.GetTotalCost());
    }

    [TestMethod]
    public void Constructor_NullName_ShouldThrow()
    {
        Assert.ThrowsException<ArgumentNullException>(() =>
            new TestProduct(null, 10m, 2m, 2));
    }

    [TestMethod]
    public void OperatorPlus_DifferentNames_ShouldThrow()
    {
        var p1 = TestData.Standard;
        var p2 = TestData.DifferentName;

        Assert.ThrowsException<ProductException>(() => _ = p1 + p2);
    }

    [TestMethod]
    public void GetUnitCost_ShouldReturnCorrectValue()
    {
        var p = TestData.Standard;
        var result = p.GetUnitCost();
        Assert.AreEqual(12m, result);
    }

    [TestMethod]
    public void GetTotalCost_ShouldReturnCorrectValue()
    {
        var p = TestData.Standard;
        var result = p.GetTotalCost();
        Assert.AreEqual(36m, result);
    }

    [TestMethod]
    public void Equals_SameValues_ShouldReturnTrue()
    {
        var p1 = TestData.Standard;
        var p2 = TestData.SameAsStandard;

        Assert.IsTrue(p1.Equals(p2));
    }

    [TestMethod]
    public void OperatorMinus_ValidSubtract_ShouldReturnReducedProduct()
    {
        var p = TestData.Standard;
        var result = p - 2;
        Assert.AreEqual(1, result.Quantity);
    }

    [TestMethod]
    public void OperatorMinus_SubtractTooMuch_ShouldThrow()
    {
        var p = TestData.QuantityOne;
        Assert.ThrowsException<ProductException>(() => _ = p - 5);
    }

    [TestMethod]
    public void ImplicitOperatorDecimal_ShouldReturnTotalCost()
    {
        var p = TestData.Standard;
        decimal result = p;
        Assert.AreEqual(36m, result);
    }

    [TestMethod]
    public void ImplicitOperatorInt_ShouldReturnTotalCostInCents()
    {
        var p = TestData.Standard;
        int result = p;
        Assert.AreEqual(3600, result); // 36.00 * 100
    }
}
