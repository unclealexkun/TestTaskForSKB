using System;
using System.Collections.Generic;

namespace Test.Classes
{
    public class TrieNode<TValue> : TrieNodeBase<TValue>
    {
        private readonly Dictionary<char, TrieNode<TValue>> mChildren;
        private readonly Queue<TValue> mValues;

        protected TrieNode()
        {
            mChildren = new Dictionary<char, TrieNode<TValue>>();
            mValues = new Queue<TValue>();
        }

        protected override int KeyLength
        {
            get { return 1; }
        }

        protected override IEnumerable<TrieNodeBase<TValue>> Children()
        {
            return mChildren.Values;
        }

        protected override IEnumerable<TValue> Values()
        {
            return mValues;
        }

        protected override TrieNodeBase<TValue> GetOrCreateChild(char key)
        {
            TrieNode<TValue> result;
            if (!mChildren.TryGetValue(key, out result))
            {
                result = new TrieNode<TValue>();
                mChildren.Add(key, result);
            }
            return result;
        }

        protected override TrieNodeBase<TValue> GetChildOrNull(string query, int position)
        {
            if (query == null) throw new ArgumentNullException("query");
            TrieNode<TValue> childNode;
            return
                mChildren.TryGetValue(query[position], out childNode)
                    ? childNode
                    : null;
        }

        protected override void AddValue(TValue value)
        {
            mValues.Enqueue(value);
        }
    }
}