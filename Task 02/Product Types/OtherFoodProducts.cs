using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class OtherFoodProducts : Products
    {
        public OtherFoodProducts()
        {
            ProductType = TypesOfGood.OtherFoodProducts;
        }

        public OtherFoodProducts(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.OtherFoodProducts, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
