using ProductManager.Core.Products;

namespace ProductManager.Core.Models
{
    public class Bakery : Product
    {
        public Bakery() { }

        public Bakery(string name, decimal purchasePrice, decimal markup, int quantity) 
            : base(name, purchasePrice, markup, quantity) { }

        protected override Product WithNewValues(decimal newPrice, decimal newMarkup, int newQuantity)
        {
            return new Bakery(Name, newPrice, newMarkup, newQuantity);
        }

        protected override Product WithQuantity(int newQuantity)
        {
            return new Bakery(Name, PurchasePrice, Markup, newQuantity);
        }
    }
}
