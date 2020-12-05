using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class Groceries : Products
    {
        public Groceries()
        {
            ProductType = TypesOfGood.Groceries;
        }

        public Groceries(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.Groceries, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
