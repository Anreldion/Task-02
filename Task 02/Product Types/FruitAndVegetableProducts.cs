using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Product_Types
{
    public class FruitAndVegetableProducts : Products
    {
        public FruitAndVegetableProducts()
        {
            ProductType = TypesOfGood.FruitAndVegetableProducts;
        }

        public FruitAndVegetableProducts(string name, double purchasePrice, double murkup, double numberOfUnits) : base(name, TypesOfGood.FruitAndVegetableProducts, purchasePrice, murkup, numberOfUnits)
        {

        }
    }
}
