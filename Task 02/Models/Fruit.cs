using ProductManager.Core.Products;

namespace ProductManager.Core.Models
{
    public class Fruit : Product
    {
        public Fruit() { }

        public Fruit(string name, decimal purchasePrice, decimal markup, int quantity)
            : base(name, purchasePrice, markup, quantity) { }
        protected override Product WithNewValues(decimal newPrice, decimal newMarkup, int newQuantity)
        {
            return new Fruit(Name, newPrice, newMarkup, newQuantity);
        }

        protected override Product WithQuantity(int newQuantity)
        {
            return new Fruit(Name, PurchasePrice, Markup, newQuantity);
        }
    }
}
