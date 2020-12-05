using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class TobaccoProducts : Products
    {
        public TobaccoProducts()
        {
            ProductType = TypesOfGood.TobaccoProducts;
        }

        public TobaccoProducts(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.TobaccoProducts, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
