using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Product_Types
{
    /// <summary>
    /// Виды товаров
    /// </summary>
    public class TypesOfGoods
    {
        public enum TypesOfGood
        {
            AlcoholicDrinks,
            BakeryProducts,
            BeekeepingProducts,
            Confectionery,
            EggProduct,
            FatAndOilProducts,
            FishProducts,
            FruitAndVegetableProducts,
            Groceries,
            MeatProducts,
            MilkProducts,
            OtherFoodProducts,
            SoftDrinks,
            TobaccoProducts,
        }

        /// <summary>
        /// Проверка на существование данного вида продукции
        /// </summary>
        /// <param name="type">Тип</param>
        /// <returns>Возвращает true - если существует, false - если не существует.</returns>
        public bool IsExcist(string type)
        {
            Array names = Enum.GetNames(typeof(TypesOfGood));
            foreach(var item in names)
            {
                if((string)item == type)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
