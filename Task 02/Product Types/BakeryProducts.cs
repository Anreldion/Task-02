using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class BakeryProducts : Products
    {
        public BakeryProducts()
        {
            ProductType = TypesOfGood.BakeryProducts;
        }

        public BakeryProducts(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.BakeryProducts, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
