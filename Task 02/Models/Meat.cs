using ProductManager.Core.Products;

namespace ProductManager.Core.Models
{
    /// <summary>
    /// Represents a meat product.
    /// </summary>
    public class Meat : Product
    {
        public Meat() { }

        public Meat(string name, decimal purchasePrice, decimal markup, int quantity) 
            : base(name, purchasePrice, markup, quantity) { }
        protected override Product WithNewValues(decimal newPrice, decimal newMarkup, int newQuantity)
        {
            return new Meat(Name, newPrice, newMarkup, newQuantity);
        }

        protected override Product WithQuantity(int newQuantity)
        {
            return new Meat(Name, PurchasePrice, Markup, newQuantity);
        }
    }
}
