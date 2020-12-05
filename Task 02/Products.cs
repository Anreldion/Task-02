using System;
using System.Text.Json.Serialization;
using static ClassLibrary.Product_Types.TypesOfGoods;

namespace ClassLibrary
{

    //****************************************************************
    // 5. Разработать иерархию классов для хранения информации о различных
    // видах товаров(наименование, закупочная цена, наценка, количество
    // единиц)
    //****************************************************************

    public class Products
    {
        private string name;
        private double purchasePrice;
        private double murkup_coefficient;
        private double numberOfUnits;
        private TypesOfGood productType;

        public Products()
        {
            ProductName = "";
            PurchasePrice = 0;
            MurkupCoefficient = 1;
            NumberOfUnits = 0;
            PriceType = Types.Rubles;
        }
        public Products(string name, TypesOfGood typesOfGood, double purchasePrice, double murkup, double numberOfUnits)
        {
            ProductName = name;
            PurchasePrice = purchasePrice;
            MurkupCoefficient = murkup;
            NumberOfUnits = numberOfUnits;
            PriceType = Types.Rubles;
            ProductType = typesOfGood;
        }

        /// <summary>
        /// Наименование продукта
        /// </summary>
        public string ProductName { get => name; set => name = value; }

        /// <summary>
        /// Тип продутка
        /// </summary>
        public TypesOfGood ProductType { get => productType; set => productType = value; }

        /// <summary>
        /// Формат цены (Рубли, копейки)
        /// </summary>
        private Types PriceType;


        /// <summary>
        /// Закупочная цена
        /// </summary>
        public double PurchasePrice { get => purchasePrice; set => purchasePrice = value; }

        [JsonIgnore]
        /// <summary>
        /// Стоимость за единицу продукции
        /// </summary>
        public double UnitCost
        {
            get
            {
                switch (PriceType)
                {
                    case Types.Rubles:
                        return this.PurchasePrice * this.MurkupCoefficient;

                    case Types.Penny:
                        int penny = (int)(this.PurchasePrice * this.MurkupCoefficient * 100);
                        return penny;

                    default:
                        return 0;
                }
            }
        }

        [JsonIgnore]
        /// <summary>
        /// Общая стоимость
        /// </summary>
        public double TotalCost
        {
            get
            {
                switch (PriceType)
                {
                    case Types.Rubles:
                        return UnitCost * NumberOfUnits;

                    case Types.Penny:
                        int penny = (int)(UnitCost * NumberOfUnits * 100);
                        return penny;

                    default:
                        return 0;
                }
            }
        }


        /// <summary>
        /// Коэффициент наценки
        /// </summary>
        public double MurkupCoefficient { get => murkup_coefficient; set => murkup_coefficient = value; }

        /// <summary>
        /// Количество единиц продукции
        /// </summary>
        public double NumberOfUnits { get => numberOfUnits; set => numberOfUnits = value; }

        public override bool Equals(object obj)
        {
            return obj is Products products &&
                   ProductName == products.ProductName &&
                   ProductType == products.ProductType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, ProductType);
        }

        public override string ToString()
        {
            string price_type = PriceType == Types.Rubles ? "р" : "коп";
            return String.Format("Вид продукции: {0}, Наименование: {1}, Закупочная цена: {2}р, Коэффициент наценки: {3}, Стоимость, шт: {4}{5}, Общая стоимость: {6}{5};",
                ProductType, ProductName, PurchasePrice, MurkupCoefficient, UnitCost.ToString("f2"), price_type, TotalCost.ToString("f2"));
        }

        //****************************************************************
        // 6. Дополнить классы методами вычисления стоимости единицы, и общей
        // стоимости
        //****************************************************************
        /// <summary>
        /// Расчет стоимости за единицу продукции
        /// </summary>
        public double CalculatingUnitCost()
        {
            return this.PurchasePrice * this.MurkupCoefficient;

        }
        /// <summary>
        /// Рассчет общей стоимости
        /// </summary>
        public double CalculatingTheTotalCost()
        {
            return CalculatingUnitCost() * this.NumberOfUnits;
        }

        //****************************************************************
        // 8. Предусмотреть операцию сложения двух одинаковых видов товаров
        // одного наименования – в этом случае цена и наценка вычисляются как
        // средневзвешенные в зависимости от количества единиц товара,
        // количество просто суммируется
        //****************************************************************

        /// <summary>
        /// Сложить исходный продукт с эквивалентным по виду и наименованию. Цена и наценка вычисляется как средневзвешенные в зависимости от количества единиц товара, количество просто суммируется.
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Возвращает true если условия выполенны</returns>
        public bool SummEqualProduct(Products product)
        {
            double price_new, murkup_new, numberOfUnits_new;
            //Вид товара и наименования совпадает?
            if (this.ProductName == product.ProductName)
            {
                //Перерасчет цены и наценки
                //Количество продуктов
                numberOfUnits_new = this.numberOfUnits + product.numberOfUnits;
                //Средневзвешенная цена
                price_new = ((this.PurchasePrice * this.numberOfUnits) + (product.PurchasePrice * product.numberOfUnits)) / numberOfUnits_new;
                //Средневзвешенная наценка
                murkup_new = ((this.MurkupCoefficient * this.numberOfUnits) + (product.MurkupCoefficient * product.numberOfUnits)) / numberOfUnits_new;

                //Присваиваем
                this.PurchasePrice = price_new;
                this.MurkupCoefficient = murkup_new;
                this.NumberOfUnits = numberOfUnits_new;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Сложение двух одинаковых видов товаров. Цена и наценка вычисляется как средневзвешенные в зависимости от количества единиц товара, количество просто суммируется.
        /// </summary>
        /// <param name="product_one">Первый продукт</param>
        /// <param name="product_two">Второй продукт</param>
        /// <returns>Возвращает новый объект</returns>
        static public Products SummEqualProduct(Products product_one, Products product_two)
        {
            double price_new, murkup_new, numberOfUnits_new;
            //Вид товара и наименования совпадает?
            if (Products.Equals(product_one, product_two))
            {
                //Перерасчет цены и наценки
                //Количество продуктов
                numberOfUnits_new = product_one.NumberOfUnits + product_two.NumberOfUnits;
                //Средневзвешенная цена
                price_new = ((product_one.PurchasePrice * product_one.NumberOfUnits) + (product_two.PurchasePrice * product_two.NumberOfUnits)) / numberOfUnits_new;
                //Средневзвешенная наценка
                murkup_new = ((product_one.MurkupCoefficient * product_one.NumberOfUnits) + (product_two.MurkupCoefficient * product_two.NumberOfUnits)) / numberOfUnits_new;

                //Создаем новый объект
                Products product = new Products { MurkupCoefficient = murkup_new, NumberOfUnits = numberOfUnits_new, ProductType = product_one.ProductType, PurchasePrice = price_new, ProductName = product_one.ProductName };

                //Возвращаем
                return product;
            }
            else
            {//выдать исключение
                throw new ProductExceptions("Виды продуктов не эквивалентны друг другу.");
            }
        }
        /// <summary>
        /// Реализация оператора сложения для класса
        /// </summary>
        /// <param name="product_one">Первый продукт</param>
        /// <param name="product_two">Второй продукт</param>
        /// <returns></returns>
        public static Products operator + (Products product_one, Products product_two)
        {            
            //Вид товара и наименования совпадает?
            if (Products.Equals(product_one, product_two))
            {
                double price_new, murkup_new, numberOfUnits_new;
                //Перерасчет цены и наценки
                //Количество продуктов
                numberOfUnits_new = product_one.NumberOfUnits + product_two.NumberOfUnits;
                //Средневзвешенная цена
                price_new = ((product_one.PurchasePrice * product_one.NumberOfUnits) + (product_two.PurchasePrice * product_two.NumberOfUnits)) / numberOfUnits_new;
                //Средневзвешенная наценка
                murkup_new = ((product_one.MurkupCoefficient * product_one.NumberOfUnits) + (product_two.MurkupCoefficient * product_two.NumberOfUnits)) / numberOfUnits_new;

                Products product = new Products { MurkupCoefficient = murkup_new, NumberOfUnits = numberOfUnits_new, ProductType = product_one.ProductType, PurchasePrice = price_new, ProductName = product_one.ProductName };

                //Возвращаем
                return product;
            }
            else
            {
                throw new ProductExceptions("Виды продуктов не эквивалентны друг другу.");
            }
        }

        //****************************************************************
        // 9. Предусмотреть операцию вычитания целого числа, в результате которой
        // будет создан новый объект данного типа с изменённым количеством
        // единиц
        //****************************************************************

        /// <summary>
        /// Вычитание количества продукции из исходного продукта
        /// </summary>
        /// <param name="value">Вычитаемое значение</param>
        /// <returns></returns>
        public bool SubtractionUnits(int value)
        {
            int numberOfUnits_new = (int)this.NumberOfUnits - value;
            if (numberOfUnits_new > 0)
            {
                this.NumberOfUnits = numberOfUnits_new;
                return true;
            }
            else
            {//выдать искулючение
                throw new ProductArgumentException("Отрицательное количество продукции", numberOfUnits_new);
            }
        }

        /// <summary>
        /// Вычитание количества продукции. В результате выполнения операции будет создан новый объект с изменённым количеством единиц
        /// </summary>
        /// <param name="product">Продукция</param>
        /// <param name="subtract">Аргумент вычитания</param>
        /// <returns>Возвращает новый объект</returns>
        static public Products SubtractionNumberOfUnits(Products product, int subtract)
        {
            int numberOfUnits_new = (int)product.NumberOfUnits - subtract;
            if (numberOfUnits_new > 0)
            {
                //Создаем новый объект
                Products new_product = new Products(product.ProductName, product.ProductType, product.PurchasePrice, product.MurkupCoefficient, numberOfUnits_new);
                return new_product;
            }
            else
            {//выдать исключение
                throw new ProductArgumentException("Отрицательное количество продукции.", numberOfUnits_new);
            }
        }
        /// <summary>
        /// Реализация вычитания целого числа
        /// </summary>
        /// <param name="product">Продукция</param>
        /// <param name="subtract_value">Вычитаемое значение</param>
        /// <returns></returns>
        public static Products operator - (Products product, int subtract_value)
        {
            int numberOfUnits_new = (int)product.NumberOfUnits - subtract_value;
            if (numberOfUnits_new > 0)
            {
                //Создаем новый объект
                Products new_product = new Products(product.ProductName, product.ProductType, product.PurchasePrice, product.MurkupCoefficient, numberOfUnits_new);
                return new_product;
            }
            else
            {//выдать исключение
                throw new ProductArgumentException("Отрицательное количество продукции.", numberOfUnits_new);
            }
        }

        //****************************************************************
        // 11. Предусмотреть возможность приведения типа товара к целочисленному
        // (стоимость возвращается в копейках) и вещественному типу
        //****************************************************************
        //Вариант 1. Через параметр

        /// <summary>
        /// Формат возвращаемой стоимости (Integer - целочисленный (в копейках), Real - вещественный (в рублях))
        /// </summary>
        public enum Types
        {
            Penny,
            Rubles,
        }
        public void PriceSetType(Types type)
        {
            PriceType = type;
        }

        //Вариант 2. Перегрузка операций преобразования типов

        public static implicit operator int(Products Products)
        {
            return (int)(Products.UnitCost * 100);
        }

        public static implicit operator double(Products Products)
        {
            return Products.UnitCost;
        }
    }
}
