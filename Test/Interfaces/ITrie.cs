using System.Collections.Generic;

namespace Test.Interfaces
{
    public interface ITrie<TValue>
    {
        IEnumerable<TValue> Retrieve(string query);
        void Add(string key, TValue value);
    }
}