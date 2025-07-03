using System.Collections.Generic;

namespace ClassLibrary.Services.Interfaces
{
    public interface IParser
    {
        string Serialize(IEnumerable<Products> input);
        IEnumerable<Products> Deserialize(string input);
    }
}
