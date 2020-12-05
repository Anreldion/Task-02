using ClassLibrary.Product_Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class ClassLibraryTests
    {
        //****************************************************************
        //Products class tests
        //****************************************************************

        /// <summary>
        /// Расчет стоимости за единицу продукции
        /// </summary>
        [TestMethod]
        public void Products_CalculatingUnitCost_Test()
        {
            // arrange
            Products product = new AlcoholicDrinks("Лидское", 2.3, 1.1, 50);
            double delta = .001;
            double expected = 2.53;

            // act 
            double unit_cost = product.CalculatingUnitCost();

            // assert 
            Assert.AreEqual(expected, unit_cost, delta);
        }

        /// <summary>
        /// Рассчет общей стоимости
        /// </summary>
        [TestMethod]
        public void Products_CalculatingTheTotalCost_Test()
        {
            // arrange
            Products product = new AlcoholicDrinks("Лидское", 2.3, 1.1, 50);
            double delta = .001;
            double expected = 126.4999;
            // act 
            double total_cost = product.CalculatingTheTotalCost();

            // assert 
            Assert.AreEqual(expected, total_cost, delta);

        }

        /// <summary>
        /// Сложить исходный продукт с эквивалентным по виду и наименованию. Исходный объект изменяется.
        /// </summary>
        [TestMethod]
        public void Products_SummEqualProduct_Test()
        {
            // arrange
            Products product_one = new AlcoholicDrinks("Лидское", 2.3, 1.1, 50);
            Products product_two = new AlcoholicDrinks("Лидское", 2.5, 1.3, 10);
            double expecterd_purchasePrice = 2.333;
            double expecterd_murkup_coefficient = 1.133;
            double expecterd_numberOfUnits = 60;
            double delta = .001;

            // act 
            bool is_true = product_one.SummEqualProduct(product_two);

            // assert 
            Assert.AreEqual(is_true, true);
            Assert.AreEqual(expecterd_purchasePrice, product_one.PurchasePrice, delta);
            Assert.AreEqual(expecterd_murkup_coefficient, product_one.MurkupCoefficient, delta);
            Assert.AreEqual(expecterd_numberOfUnits, product_one.NumberOfUnits, delta);
        }

        /// <summary>
        /// Сложение двух одинаковых видов товаров. Операция возвращает новый объект.
        /// </summary> 
        [TestMethod]
        public void Products_SummEqualProducts_Test()
        {
            // arrange
            Products product_one = new MilkProducts("Ряженка", 2.5, 1.3, 100);
            Products product_two = new MilkProducts("Ряженка", 3.5, 1.5, 10);
            Products product_three;

            string expecterd_name = "Ряженка";
            double expecterd_purchasePrice = 2.5909;
            double expecterd_murkup_coefficient = 1.3181;
            double expecterd_numberOfUnits = 110;
            TypesOfGood expecterd_productType = TypesOfGood.MilkProducts;

            double delta = .001;

            // act 
            product_three = Products.SummEqualProduct(product_one, product_two);

            // assert 
            Assert.AreEqual(expecterd_name, product_three.ProductName);
            Assert.AreEqual(expecterd_productType, product_three.ProductType);
            Assert.AreEqual(expecterd_purchasePrice, product_three.PurchasePrice, delta);
            Assert.AreEqual(expecterd_murkup_coefficient, product_three.MurkupCoefficient, delta);
            Assert.AreEqual(expecterd_numberOfUnits, product_three.NumberOfUnits);
        }

        /// <summary>
        /// Вариант 1. Проверка возможности приведения типа товара к целочисленному (стоимость возвращается в копейках) и вещественному типу. 
        /// </summary>
        [TestMethod]
        public void Products_PriceType_Test()
        {
            // arrange
            Products product_one = new AlcoholicDrinks("Лидское", 2.5, 1.3, 10);
            double expecterd_Rubles = 3.25;
            int expecterd_Penny = 325;
            double delta = .001;

            // act 

            product_one.PriceSetType(Products.Types.Penny);
            int penny = (int)product_one.UnitCost;

            product_one.PriceSetType(Products.Types.Rubles);
            double rubles = product_one.UnitCost;
            

            // assert 
            Assert.AreEqual(expecterd_Rubles, rubles, delta);
            Assert.AreEqual(expecterd_Penny, penny);
        }

        /// <summary>
        /// Вариант 2. Проверка возможности приведения типа товара к целочисленному (стоимость возвращается в копейках) и вещественному типу. 
        /// </summary>
        [TestMethod]
        public void Products_GetPriceType_Test()
        {
            // arrange
            Products product = new AlcoholicDrinks("Лидское", 2.5, 1.3, 10);
            double expecterd_Rubles = 3.25;
            int expecterd_Penny = 325;
            double delta = .001;
            double rubles;
            int penny;
            // act 
            rubles = product;
            penny = product;

            // assert 
            Assert.AreEqual(expecterd_Rubles, rubles, delta);
            Assert.AreEqual(expecterd_Penny, penny);
        }

        /// <summary>
        /// Вычитание количества продукции. Исходный объект изменяется.
        /// </summary> 
        [TestMethod]
        public void Products_SubtractionUnits_Test()
        {
            // arrange
            Products product_one = new AlcoholicDrinks("Лидское", 2.3, 1.1, 50);
            int value = 5;
            double expecterd_numberOfUnits = 45;

            // act 
            product_one.SubtractionUnits(value);

            // assert 
            Assert.AreEqual(expecterd_numberOfUnits, product_one.NumberOfUnits);
        }

        //****************************************************************
        //JSON TESTS
        //****************************************************************

        /// <summary>
        /// Cериализовать объект в json. Десериализовать код json в объект C#.
        /// </summary>
        [TestMethod]
        public void JSON_SerializeDeserializeObject_Test()
        {
            // arrange
            Products product = new AlcoholicDrinks("Лидское", 2.3, 1.1, 50);

            string expecterd_name = "Лидское";
            double expecterd_purchasePrice = 2.3;
            double expecterd_murkup_coefficient = 1.1;
            double expecterd_numberOfUnits = 50;
            TypesOfGood expecterd_productType = TypesOfGood.AlcoholicDrinks;

            double delta = .001;

            // act 
            string json = JSONConverter.Serialize(product);
            Products product_JSON;
            JSONConverter.Deserialize(json, out product_JSON);

            // assert 
            Assert.AreEqual(expecterd_name, product_JSON.ProductName);
            Assert.AreEqual(expecterd_productType, product_JSON.ProductType);
            Assert.AreEqual(expecterd_purchasePrice, product_JSON.PurchasePrice, delta);
            Assert.AreEqual(expecterd_murkup_coefficient, product_JSON.MurkupCoefficient, delta);
            Assert.AreEqual(expecterd_numberOfUnits, product_JSON.NumberOfUnits, delta);
        }

        /// <summary>
        /// Cериализовать список объектов в json. Десериализовать код json в список объектов C#.
        /// </summary>
        [TestMethod]
        public void JSON_SerializeDeserializeList_Test()
        {
            // arrange
            int index = 0;
            List<Products> product_list = new List<Products>
            {
                new AlcoholicDrinks { ProductName = "Лидское", PurchasePrice = 2.3, MurkupCoefficient = 1.1, NumberOfUnits = 50 },
                new SoftDrinks { ProductName = "Krysler", PurchasePrice = 2.5, MurkupCoefficient = 1.3, NumberOfUnits = 50 },
                new TobaccoProducts { ProductName = "Winston", PurchasePrice = 2, MurkupCoefficient = 1.3, NumberOfUnits = 50 }
            };

            double delta = .001;

            // act 
            string json = JSONConverter.Serialize(product_list);
            List<Products> product_list_json;
            JSONConverter.Deserialize(json, out product_list_json);

            // assert 
            foreach (var item in product_list_json)
            {
                Assert.AreEqual(product_list[index].ProductName, item.ProductName);
                Assert.AreEqual(product_list[index].ProductType, item.ProductType);
                Assert.AreEqual(product_list[index].PurchasePrice, item.PurchasePrice, delta);
                Assert.AreEqual(product_list[index].MurkupCoefficient, item.MurkupCoefficient, delta);
                Assert.AreEqual(product_list[index].NumberOfUnits, item.NumberOfUnits, delta);

                index++;
            }
        }

        /// <summary>
        /// Из файла. Cериализовать объект в json. Десериализовать код json в объект C#.
        /// </summary>
        [TestMethod]
        public void JSON_SerializeDeserializeObjectFromFile_Test()
        {
            // arrange
            Products product = new AlcoholicDrinks("Лидское", 2.3, 1.1, 50);

            string expecterd_name = "Лидское";
            double expecterd_purchasePrice = 2.3;
            double expecterd_murkup_coefficient = 1.1;
            double expecterd_numberOfUnits = 50;
            TypesOfGood expecterd_productType = TypesOfGood.AlcoholicDrinks;
            double delta = .001;
            Products product_JSON;

            // act 
            JSONConverter.SerializeToFile("test.json", product);
            JSONConverter.DeserializeFromFile("test.json", out product_JSON);

            // assert 
            Assert.AreEqual(expecterd_name, product_JSON.ProductName);
            Assert.AreEqual(expecterd_productType, product_JSON.ProductType);
            Assert.AreEqual(expecterd_purchasePrice, product_JSON.PurchasePrice, delta);
            Assert.AreEqual(expecterd_murkup_coefficient, product_JSON.MurkupCoefficient, delta);
            Assert.AreEqual(expecterd_numberOfUnits, product_JSON.NumberOfUnits, delta);
        }

        /// <summary>
        /// Из файла. Cериализовать список объектов в json. Десериализовать код json в список объектов C#.
        /// </summary>
        [TestMethod]
        public void JSON_SerializeDeserializeListFromFile_Test()
        {
            // arrange
            int index = 0;
            List<Products> product_list = new List<Products>
            {
                new AlcoholicDrinks { ProductName = "Лидское", PurchasePrice = 2.3, MurkupCoefficient = 1.1, NumberOfUnits = 50 },
                new SoftDrinks { ProductName = "Krysler", PurchasePrice = 2.5, MurkupCoefficient = 1.3, NumberOfUnits = 50 },
                new TobaccoProducts { ProductName = "Winston", PurchasePrice = 2, MurkupCoefficient = 1.3, NumberOfUnits = 50 }
            };
            double delta = .001;
            List<Products> product_list_json;

            // act 
            JSONConverter.SerializeToFile("test.json", product_list);
            JSONConverter.DeserializeFromFile("test.json", out product_list_json);

            // assert 
            foreach (var item in product_list_json)
            {
                Assert.AreEqual(product_list[index].ProductName, item.ProductName);
                Assert.AreEqual(product_list[index].ProductType, item.ProductType);
                Assert.AreEqual(product_list[index].PurchasePrice, item.PurchasePrice, delta);
                Assert.AreEqual(product_list[index].MurkupCoefficient, item.MurkupCoefficient, delta);
                Assert.AreEqual(product_list[index].NumberOfUnits, item.NumberOfUnits, delta);

                index++;
            }
        }

    }
}
