using ClassLibrary.Products;

namespace ClassLibrary.Product_Types
{
    public class Fruit : Product
    {
        public Fruit() { }

        public Fruit(string name, decimal purchasePrice, decimal markup, double numberOfUnits)
            : base(name, purchasePrice, markup, numberOfUnits) { }
    }
}
