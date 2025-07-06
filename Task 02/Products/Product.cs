using ProductManager.Core.Utilities;
using System;

namespace ProductManager.Core.Products
{
    /// <summary>
    /// Abstract base class representing a generic product with core properties and behaviors.
    /// </summary>
    public abstract class Product : IProduct
    {
        public string Name { get; set; }

        public decimal PurchasePrice { get; set; }

        public decimal Markup { get; set; }

        public int Quantity { get; set; }

        public Product() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="name">Product name.</param>
        /// <param name="purchasePrice">Purchase price.</param>
        /// <param name="markup">Markup added to the purchase price.</param>
        /// <param name="quantity">Quantity in stock.</param>
        protected Product(string name, decimal purchasePrice, decimal markup, int quantity)
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

        /// <summary>
        /// Gets the unit cost (purchase price + markup).
        /// </summary>
        public decimal GetUnitCost() => PurchasePrice + Markup;

        /// <summary>
        /// Gets the total cost for all units.
        /// </summary>
        public decimal GetTotalCost() => GetUnitCost() * Quantity;

        public override bool Equals(object obj)
        {
            if (obj is not Product other) return false;

            return Name == other.Name &&
                   Markup == other.Markup &&
                   PurchasePrice == other.PurchasePrice &&
                   Quantity == other.Quantity &&
                   GetType() == other.GetType();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Quantity, Markup, PurchasePrice, GetType());
        }

        public override string ToString()
        {
            return
                $"Type: {GetType().Name}, Name: {Name}, Purchase Price: {PurchasePrice}$, Markup: {Markup}, " +
                $"Price per unit: {GetUnitCost():F2}$, Total Price: {GetTotalCost():F2}$;";
        }

        /// <summary>
        /// Adds two products of the same type and name, combining quantities and averaging prices and markups.
        /// </summary>
        public static Product operator +(Product a, Product b)
        {
            Guard.NotNull(a, nameof(a));
            Guard.NotNull(b, nameof(b));

            if (a.Name != b.Name || a.GetType() != b.GetType())
                throw new ProductException("Products must have the same name and type to be added.");

            int newQuantity = a.Quantity + b.Quantity;
            decimal newPrice = (a.PurchasePrice * a.Quantity + b.PurchasePrice * b.Quantity) / newQuantity;
            decimal newMarkup = (a.Markup * a.Quantity + b.Markup * b.Quantity) / newQuantity;

            return a.WithNewValues(newPrice, newMarkup, newQuantity);
        }

        /// <summary>
        /// Subtracts quantity from a product, returning a new instance with reduced quantity.
        /// </summary>
        public static Product operator -(Product product, int subtractValue)
        {
            Guard.NotNull(product, nameof(product));
            if (subtractValue < 0)
                throw new ArgumentOutOfRangeException(nameof(subtractValue), "Cannot subtract negative quantity.");
            if (subtractValue > product.Quantity)
                throw new ProductException("Cannot subtract more units than available.");

            return product.WithQuantity(product.Quantity - subtractValue);
        }

        /// <summary>
        /// Returns a new instance of the product with updated values.
        /// </summary>
        protected abstract Product WithNewValues(decimal newPrice, decimal newMarkup, int newQuantity);

        /// <summary>
        /// Returns a new instance of the product with updated quantity.
        /// </summary>
        protected abstract Product WithQuantity(int newQuantity);

        /// <summary>
        /// Converts the product to an integer (total price in cents).
        /// </summary>
        public static implicit operator int(Product product)
        {
            return (int)(product.GetTotalCost() * 100);
        }

        /// <summary>
        /// Converts the product to a decimal (total price).
        /// </summary>
        public static implicit operator decimal(Product product)
        {
            return product.GetTotalCost();
        }
    }
}
