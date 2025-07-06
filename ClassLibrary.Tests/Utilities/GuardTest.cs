using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductManager.Core.Utilities;

namespace ClassLibrary.Tests.Utilities;

[TestClass]
public class GuardTest
{

    [TestMethod]
    public void NotNull_ThrowsException()
    {
        string value = null;
        Assert.Throws<ArgumentNullException>(() =>
        {
            Guard.NotNull(value, nameof(value));
        });
    }

    [TestMethod]
    public void NotNull_DoesNotThrowException()
    {
        const string value = "notNull";
        Assert.DoesNotThrow(() =>
        {
            Guard.NotNull(value, nameof(value));
        });
    }
    [TestMethod]
    public void NotEmpty_ThrowsException()
    {
        var value = string.Empty;
        Assert.Throws<InvalidOperationException>(() =>
        {
            Guard.NotEmpty(value, nameof(value));
        });
    }

    [TestMethod]
    public void NotEmpty_DoesNotThrowException()
    {
        const string value = "notNull";
        Assert.DoesNotThrow(() =>
        {
            Guard.NotEmpty(value, nameof(value));
        });
    }
    [TestMethod]
    public void AgainstNegative_ThrowsException()
    {
        const int value = -1;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            Guard.AgainstNegative(value, nameof(value));
        });
    }

    [TestMethod]
    public void AgainstNegative_DoesNotThrowException()
    {
        const int value = 1;
        Assert.DoesNotThrow(() =>
        {
            Guard.AgainstNegative(value, nameof(value));
        });
    }
    [TestMethod]
    public void AgainstZero_ThrowsException()
    {
        const int value = 0;
        Assert.Throws<ArgumentOutOfRangeException>(() =>
        {
            Guard.AgainstZero(value, nameof(value));
        });
    }

    [TestMethod]
    public void AgainstZero_DoesNotThrowException()
    {
        const int value = 1;
        Assert.DoesNotThrow(() =>
        {
            Guard.AgainstZero(value, nameof(value));
        });
    }
}