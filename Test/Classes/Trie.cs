using System.Collections.Generic;
using Test.Interfaces;

namespace Test.Classes
{
    public class Trie<TValue> : TrieNode<TValue>, ITrie<TValue>
    {
        public IEnumerable<TValue> Retrieve(string query)
        {
            return Retrieve(query, 0);
        }

        public void Add(string key, TValue value)
        {
            Add(key, 0, value);
        }
    }
}