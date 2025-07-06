using ClassLibrary.Products;

namespace ClassLibrary.Product_Types
{
    public class Fish : Product
    {
        public Fish() { }

        public Fish(string name, decimal purchasePrice, decimal markup, double numberOfUnits) 
            : base(name, purchasePrice, markup, numberOfUnits) { }
    }
}
