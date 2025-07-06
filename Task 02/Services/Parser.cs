using ClassLibrary.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using ClassLibrary.Products;
using ClassLibrary.Utilities;

namespace ClassLibrary.Services
{
    /// <summary>
    /// Provides functionality to serialize and deserialize arrays of <see cref="Products"/> objects to and from JSON format.
    /// Supports enum values as strings and case-insensitive property names.
    /// </summary>
    public class Parser : IParser
    {
        /// <summary>
        /// Static options used by the JSON serializer to format and parse JSON content.
        /// </summary>
        private static readonly JsonSerializerOptions Options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true, 
            WriteIndented = true               
        };

        /// <summary>
        /// Static constructor to configure additional JSON settings such as enum string conversion.
        /// </summary>
        static Parser()
        {
            Options.Converters.Add(new JsonStringEnumConverter());
        }

        /// <summary>
        /// Deserializes a JSON string into an array of <see cref="Products"/> objects.
        /// Returns an empty array if the input is null or whitespace.
        /// </summary>
        /// <param name="input">The JSON string representing baked products.</param>
        /// <returns>
        /// An array of <see cref="Products"/> objects, or an empty array if the input is empty.
        /// </returns>
        public IEnumerable<Product> Deserialize(string input)=> string.IsNullOrWhiteSpace(input)
                ? []
                : JsonSerializer.Deserialize<List<Product>>(input, Options);

        /// <summary>
        /// Serializes an array of <see cref="Products"/> objects into a formatted JSON string.
        /// </summary>
        /// <param name="input">The array of baked products to serialize.</param>
        /// <returns>A JSON-formatted string representing the baked products.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the input is null.</exception>
        public string Serialize(IEnumerable<Product> input)
        {
            Guard.NotNull(input, nameof(input));

            return JsonSerializer.Serialize(input, Options);
        }
    }
}
