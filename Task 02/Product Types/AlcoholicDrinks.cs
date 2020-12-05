using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class AlcoholicDrinks : Products
    {
        public AlcoholicDrinks()
        {
            ProductType = TypesOfGood.AlcoholicDrinks;
        }

        public AlcoholicDrinks(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.AlcoholicDrinks, purchasePrice, murkup, numberOfUnits)
        {

        }

    }
}
