using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class Confectionery : Products
    {
        public Confectionery()
        {
            ProductType = TypesOfGood.Confectionery;
        }
        public Confectionery(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.Confectionery, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
