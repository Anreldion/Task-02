using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class SoftDrinks : Products
    {
        public SoftDrinks()
        {
            ProductType = TypesOfGood.SoftDrinks;
        }

        public SoftDrinks(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.SoftDrinks, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
