using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class EggProduct : Products
    {
        public EggProduct()
        {
            ProductType = TypesOfGood.EggProduct;
        }

        public EggProduct(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.EggProduct, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
