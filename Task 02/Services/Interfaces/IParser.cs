using System.Collections.Generic;
using ClassLibrary.Products;

namespace ClassLibrary.Services.Interfaces
{
    public interface IParser
    {
        string Serialize(IEnumerable<Product> input);
        IEnumerable<Product> Deserialize(string input);
    }
}
