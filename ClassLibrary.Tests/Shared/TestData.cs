using ProductManager.Tests.Shared;

namespace ProductManager.Tests.Shared
{
    /// <summary>
    /// Provides reusable test data for product-related tests.
    /// </summary>
    public static class TestData
    {
        public static TestProduct Standard => new("Standard", 10m, 2m, 3);
        public static TestProduct SameAsStandard => new("Standard", 10m, 2m, 3);

        public static TestProduct Expensive => new("Standard", 20m, 5m, 1);
        public static TestProduct DifferentName => new("Different", 10m, 2m, 3);
        public static TestProduct QuantityOne => new("Standard", 10m, 2m, 1);
        public static TestProduct QuantityTwo => new("Standard", 10m, 2m, 2);

        public static TestProduct NegativeMarkup => new("Standard", 10m, -1m, 2); 
        public static TestProduct NegativePrice => new("Standard", -10m, 1m, 2);  
        public static TestProduct NegativeQuantity => new("Standard", 10m, 2m, -2);
    }
}