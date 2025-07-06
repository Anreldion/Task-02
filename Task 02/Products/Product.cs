using ProductManager.Core.Utilities;
using System;

namespace ProductManager.Core.Products
{
    public abstract class Product : IProduct
    {
        public string Name { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal Markup { get; set; }

        public int Quantity { get; set; }

        private const double Tolerance = 0.01;

        public Product() { }

        public Product(string name, decimal purchasePrice, decimal markup, int quantity)
        {
            Guard.NotNull(name, nameof(name));
            Guard.AgainstNegative(quantity, nameof(quantity));
            Guard.AgainstNegative(purchasePrice, nameof(purchasePrice));
            Guard.AgainstNegative(markup, nameof(markup));

            Name = name;
            PurchasePrice = purchasePrice;
            Markup = markup;
            Quantity = quantity;
        }

        public decimal GetUnitCost()
        {
            return PurchasePrice * Markup;
        }

        public decimal GetTotalCost()
        {
            return GetUnitCost() * (decimal)Quantity;
        }

        public override bool Equals(object obj)
        {
            return obj is Product products &&
                   Name == products.Name &&
                   Math.Abs(Quantity - products.Quantity) < Tolerance &&
                   Markup == products.Markup &&
                   PurchasePrice == products.PurchasePrice;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Quantity, Markup, PurchasePrice);
        }

        public override string ToString()
        {
            return
                $"Type: {nameof(Product)}, Name: {Name}, Purchase Price: {PurchasePrice}$, Markup: {Markup}, Price for 1 unit: {GetUnitCost():f2}, Price: {GetTotalCost():f2};";
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


            var newQuantity = productOne.Quantity + productTwo.Quantity;
            var newPrice = (productOne.PurchasePrice * productOne.Quantity + productTwo.PurchasePrice * productTwo.Quantity) / newQuantity;
            var newMarkup = (productOne.Markup * productOne.Quantity + productTwo.Markup * productTwo.Quantity) / newQuantity;

            return productOne.WithNewValues(newPrice, newMarkup, newQuantity);
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
            return product.WithQuantity(product.Quantity - subtractValue);
        }

        protected abstract Product WithNewValues(decimal newPrice, decimal newMarkup, int newQuantity);
        protected abstract Product WithQuantity(int newQuantity);


        /// <summary>
        /// Приведения типа товара к целочисленному
        /// </summary>
        /// <param name="product"></param>
        public static implicit operator int(Product product)
        {
            return (int)(product.GetTotalCost() * 100);
        }
        /// <summary>
        /// Приведения типа товара к вещественному
        /// </summary>
        /// <param name="product"></param>
        public static implicit operator decimal(Product product)
        {
            return product.GetTotalCost();
        }
    }
}
