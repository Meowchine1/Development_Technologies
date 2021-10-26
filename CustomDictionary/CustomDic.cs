using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDictionary
{
    public class CustomDic<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
        {
            private List<TValue>[] _items;
  
        public int Count() => _items.Count();

        int ICollection<KeyValuePair<TKey, TValue>>.Count => throw new NotImplementedException();
        public bool IsReadOnly => throw new NotImplementedException();

        public CustomDic(int size)
            {
                _items = new List<TValue>[size];
            }

            private int GetHash(TKey key)
            {
                return Convert.ToInt32(key.ToString().Substring(0,1));
            }

            public void Add(TKey key, TValue value)
            {
                var k = GetHash(key);
            if (_items[k] == null)
            {
                _items[k] = new List<TValue>() { value };//*
            }
            else
            {
                _items[k].Add(value);//*
            }
            }
            public bool Search(TKey key, TValue value)
            {
                var k = GetHash(key);
                return _items[k].Contains(value);//*
            }
       public  void Remove(TKey key, TValue value)
        {
            var k = GetHash(key);
            if (_items[k] == null)  
            {}
            else
            {
                _items[k].Remove(value);//*
            }
        }
   

        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<TKey, TValue>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

       

        IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
    }
    }

