using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class MilkProducts : Products
    {
        public MilkProducts()
        {
            ProductType = TypesOfGood.MilkProducts;
        }

        public MilkProducts(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.MilkProducts, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
