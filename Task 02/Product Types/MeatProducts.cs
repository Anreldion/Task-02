using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class MeatProducts : Products
    {
        public MeatProducts()
        {
            ProductType = TypesOfGood.MeatProducts;
        }

        public MeatProducts(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.MeatProducts, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
