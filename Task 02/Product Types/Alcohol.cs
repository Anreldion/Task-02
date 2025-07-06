using ClassLibrary.Products;

namespace ClassLibrary.Product_Types
{
    public class Alcohol : Product
    {
        public Alcohol() { }

        public Alcohol(string name, decimal purchasePrice, decimal markup, double numberOfUnits) :
            base(name, purchasePrice, markup, numberOfUnits)
        { }
    }
}
