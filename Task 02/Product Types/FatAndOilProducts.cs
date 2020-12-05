using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class FatAndOilProducts : Products
    {
        public FatAndOilProducts()
        {
            ProductType = TypesOfGood.FatAndOilProducts;
        }

        public FatAndOilProducts(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.FatAndOilProducts, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
