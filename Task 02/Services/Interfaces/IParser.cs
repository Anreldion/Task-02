using System.Collections.Generic;
using ProductManager.Core.Products;

namespace ProductManager.Core.Services.Interfaces
{
    public interface IParser
    {
        string Serialize(IEnumerable<Product> input);
        IEnumerable<Product> Deserialize(string input);
    }
}
