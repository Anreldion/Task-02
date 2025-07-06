using ClassLibrary.Products;

namespace ClassLibrary.Product_Types
{
    public class Meat : Product
    {
        public Meat() { }

        public Meat(string name, decimal purchasePrice, decimal markup, double numberOfUnits) 
            : base(name, purchasePrice, markup, numberOfUnits) { }
    }
}
