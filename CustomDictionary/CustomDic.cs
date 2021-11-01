using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CustomDictionary
{
    public class CustomDic<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
      private  Dictionary<TKey, TValue>[] _items;

        public CustomDic(int size)
        {
            _items = new Dictionary<TKey, TValue>[size];
        }


        private int GetHash(TKey key)
        {
            return key.GetHashCode();
        }


        public void Add(TKey key, TValue value)
        {
            var k = GetHash(key);
            if (_items[k] == null)
            {
                _items[k] = new Dictionary<TKey, TValue>();  //*
            }
            else
            {
                _items[k].Add(key , value);//*
            }
        }


        public bool Search(TKey key, TValue value)
        {
            var k = GetHash(key);
            return _items[k].ContainsKey(key) && _items[k].ContainsValue(value);//*
        }



        public void Remove(TKey key, TValue value)
        {
            var k = GetHash(key);
            if (_items[k] == null)
            { }
            else
            {
                if (_items[k].ContainsValue(value))
                _items[k].Remove(key);//*
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public class DictEnumerator<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>>
    {
        private Dictionary<TKey, TValue>[] _items;
        private int iterator = -1;

        public static KeyValuePair<TKey, TValue> Convert_dict(Dictionary<TKey, TValue> _items)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(KeyValuePair<TKey, TValue>));

            return (KeyValuePair<TKey, TValue>)converter.ConvertFrom(_items);
        }

        public DictEnumerator(Dictionary<TKey, TValue>[] _items)
        {
            this._items = _items;
        
        }

        public KeyValuePair<TKey, TValue> Current => Convert_dict(_items[iterator]); // ???



        object IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            iterator++;
            return iterator < _items.Length;
        }

        public void Reset()
        {
            iterator = -1;
        }


        public void katya()
        {
            
        }
    }
}


