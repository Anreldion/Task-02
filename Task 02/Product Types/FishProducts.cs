using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class FishProducts : Products
    {
        public FishProducts()
        {
            ProductType = TypesOfGood.FishProducts;
        }

        public FishProducts(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.FishProducts, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
