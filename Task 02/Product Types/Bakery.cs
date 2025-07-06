using ClassLibrary.Products;

namespace ClassLibrary.Product_Types
{
    public class Bakery : Product
    {
        public Bakery() { }

        public Bakery(string name, decimal purchasePrice, decimal markup, double numberOfUnits) 
            : base(name, purchasePrice, markup, numberOfUnits) { }
    }
}
