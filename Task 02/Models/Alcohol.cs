using ProductManager.Core.Products;

namespace ProductManager.Core.Models
{
    /// <summary>
    /// Represents a alcohol product.
    /// </summary>
    public class Alcohol : Product
    {
        public Alcohol() { }

        public Alcohol(string name, decimal purchasePrice, decimal markup, int quantity) :
            base(name, purchasePrice, markup, quantity)
        { }

        protected override Product WithNewValues(decimal newPrice, decimal newMarkup, int newQuantity)
        {
            return new Alcohol(Name, newPrice, newMarkup, newQuantity);
        }

        protected override Product WithQuantity(int newQuantity)
        {
            return new Alcohol(Name, PurchasePrice, Markup, newQuantity);
        }
    }
}
