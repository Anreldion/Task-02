using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class BeekeepingProducts : Products
    {
        public BeekeepingProducts()
        {
            ProductType = TypesOfGood.BeekeepingProducts;
        }

        public BeekeepingProducts(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.BeekeepingProducts, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
