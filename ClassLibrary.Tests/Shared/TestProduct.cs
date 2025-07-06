using ProductManager.Core.Products;

namespace ProductManager.Tests.Shared
{
    /// <summary>
    /// Minimal concrete implementation of abstract Product for unit testing.
    /// </summary>
    public class TestProduct : Product
    {
        public TestProduct(){}

        public TestProduct(string name, decimal price, decimal markup, int quantity)
            : base(name, price, markup, quantity) { }

        protected override Product WithNewValues(decimal newPrice, decimal newMarkup, int newQuantity)
        {
            return new TestProduct(Name, newPrice, newMarkup, newQuantity);
        }

        protected override Product WithQuantity(int newQuantity)
        {
            return new TestProduct(Name, PurchasePrice, Markup, newQuantity);
        }
    }
}