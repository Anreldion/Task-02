using Newtonsoft.Json;
using ProductManager.Core.Products;
using ProductManager.Core.Services.Interfaces;
using ProductManager.Core.Utilities;
using System.Collections.Generic;

namespace ProductManager.Core.Services
{
    /// <summary>
    /// Provides functionality to serialize and deserialize collections of <see cref="Product"/> objects
    /// using the Newtonsoft.Json library. Supports polymorphic types via TypeNameHandling.Auto.
    /// </summary>
    public class Parser : IParser
    {
        /// <summary>
        /// Global JSON serializer settings used for formatting and preserving type information.
        /// </summary>
        private static readonly JsonSerializerSettings Settings = new()
        {
            // Enables automatic storage of type metadata for proper polymorphic deserialization
            TypeNameHandling = TypeNameHandling.Auto,
            Formatting = Formatting.Indented
        };

        /// <summary>
        /// Deserializes a JSON string into a list of <see cref="Product"/> objects.
        /// </summary>
        /// <param name="input">A JSON-formatted string representing a list of products.</param>
        /// <returns>
        /// A list of <see cref="Product"/> objects, or an empty list if the input is null or whitespace.
        /// </returns>
        public IEnumerable<Product> Deserialize(string input) =>
            string.IsNullOrWhiteSpace(input)
                ? []
                : JsonConvert.DeserializeObject<List<Product>>(input, Settings);

        /// <summary>
        /// Serializes a list of <see cref="Product"/> objects into a JSON-formatted string.
        /// </summary>
        /// <param name="input">The list of products to serialize.</param>
        /// <returns>A JSON string that represents the input products.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the input list is null.</exception>
        public string Serialize(IEnumerable<Product> input)
        {
            Guard.NotNull(input, nameof(input));
            return JsonConvert.SerializeObject(input, Settings);
        }
    }
}
