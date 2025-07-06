using System;
using ClassLibrary.Utilities;

namespace ClassLibrary.Products
{
    public class Product : IProduct 
    {
        public string Name { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal Markup { get; set; }

        public double Count { get; set; }

        private const double Tolerance = 0.01;

        public Product() { }

        public Product(string name, decimal purchasePrice, decimal markup, double count)
        {
            Guard.NotNull(name, nameof(name));
            Guard.AgainstNegative(count, nameof(count));
            Guard.AgainstNegative(purchasePrice, nameof(purchasePrice));
            Guard.AgainstNegative(markup, nameof(markup));

            Name = name;
            PurchasePrice = purchasePrice;
            Markup = markup;
            Count = count;
        }

        public decimal GetPriceForUnit()
        {
            return PurchasePrice * Markup;
        }

        public decimal GetPrice()
        {
            return GetPriceForUnit() * (decimal)Count;
        }

        public override bool Equals(object obj)
        {
            return obj is Product products &&
                   Name == products.Name &&
                   Math.Abs(Count - products.Count) < Tolerance &&
                   Markup == products.Markup &&
                   PurchasePrice == products.PurchasePrice;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Count, Markup, PurchasePrice);
        }

        public override string ToString()
        {
            return
                $"Type: {nameof(Product)}, Name: {Name}, Purchase Price: {PurchasePrice}$, Markup: {Markup}, Price for 1 unit: {GetPriceForUnit():f2}, Price: {GetPrice():f2};";
        }

        /// <summary>
        /// Предусмотреть операцию сложения двух одинаковых видов товаров
        /// одного наименования – в этом случае цена и наценка вычисляются как
        /// средневзвешенные в зависимости от количества единиц товара, количество просто суммируется
        /// </summary>
        /// <param name="productOne">Первый продукт</param>
        /// <param name="productTwo">Второй продукт</param>
        /// <returns></returns>
        public static Product operator +(Product productOne, Product productTwo)
        {
            Guard.NotNull(productOne, nameof(productOne));
            Guard.NotNull(productTwo, nameof(productTwo));

            if (!Equals(productOne, productTwo))
                throw new ProductExceptions("Products unequal");


            var count = productOne.Count + productTwo.Count;
            var price = (productOne.PurchasePrice * (decimal) productOne.Count + productTwo.PurchasePrice * (decimal) productTwo.Count) / (decimal) count;
            var markup = (productOne.Markup * (decimal) productOne.Count + productTwo.Markup * (decimal) productTwo.Count) / (decimal) count;

            var product = new Product
            {
                Markup = markup,
                Count = productOne.Count + productTwo.Count,
                
                PurchasePrice = price,
                Name = productOne.Name
            };

            return product;

        }

        /// <summary>
        /// Предусмотреть операцию вычитания целого числа, в результате которой
        /// будет создан новый объект данного типа с изменённым количеством единиц
        /// </summary>
        /// <param name="product">Продукция</param>
        /// <param name="subtractValue">Вычитаемое значение</param>
        /// <returns></returns>
        public static Product operator -(Product product, int subtractValue)
        {
            var numberOfUnitsNew = (int)product.Count - subtractValue;
            if (numberOfUnitsNew <= 0)
                throw new ProductArgumentException("Отрицательное количество продукции.", numberOfUnitsNew);

            var newProduct = new Product(product.Name, product.PurchasePrice, product.Markup, numberOfUnitsNew);
            return newProduct;
        }

        /// <summary>
        /// Приведения типа товара к целочисленному
        /// </summary>
        /// <param name="product"></param>
        public static implicit operator int(Product product)
        {
            return (int)(product.GetPrice() * 100);
        }
        /// <summary>
        /// Приведения типа товара к вещественному
        /// </summary>
        /// <param name="product"></param>
        public static implicit operator decimal(Product product)
        {
            return product.GetPrice();
        }
    }
}
