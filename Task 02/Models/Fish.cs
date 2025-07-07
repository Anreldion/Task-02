using ProductManager.Core.Products;

namespace ProductManager.Core.Models
{
    /// <summary>
    /// Represents a fish product.
    /// </summary>
    public class Fish : Product
    {
        public Fish() { }

        public Fish(string name, decimal purchasePrice, decimal markup, int quantity) 
            : base(name, purchasePrice, markup, quantity) { }
        protected override Product WithNewValues(decimal newPrice, decimal newMarkup, int newQuantity)
        {
            return new Fish(Name, newPrice, newMarkup, newQuantity);
        }

        protected override Product WithQuantity(int newQuantity)
        {
            return new Fish(Name, PurchasePrice, Markup, newQuantity);
        }

    }
}
