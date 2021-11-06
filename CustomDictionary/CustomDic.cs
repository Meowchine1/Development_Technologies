using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CustomDictionary
{
    public class CustomDic<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>,  ICollection<KeyValuePair<TKey, TValue>>
    {
        const int MaxArrayLimit = 3;

        private int _count = 0;

        private LinkedList<KeyValuePair<TKey, TValue>>[] _data;

        public int Count => _count;

        public bool IsReadOnly => false;

        public CustomDic()
        {
            _data = new LinkedList<KeyValuePair<TKey, TValue>>[8];
        }

        public void Add(TKey key, TValue value)
        {
            var hash = key.GetHashCode();
            var index = ((hash % _data.Length) + _data.Length) % _data.Length;

            if (_data[index] is null)
            {
                _data[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
                _data[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
                _count++;

                if (_data.Length / 3 <= _count)
                {
                    ReCreateArray();
                }

                return;
            }

            foreach (var kvp in _data[index])
            {
                if (kvp.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists.", nameof(key));
                }
            }

            _data[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            _count++;

            if (_data.Length / 3 <= _count)
            {
                ReCreateArray();
            }
        }

        private void ReCreateArray()
        {
            var newLength = _data.Length * 3;

            var oldData = _data;

            _data = new LinkedList<KeyValuePair<TKey, TValue>>[newLength];

            foreach (var list in oldData)
            {
                foreach (var kvp in list)
                {
                    Add(kvp.Key, kvp.Value);
                }
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
            foreach (var linkedList in _data)
            {
                foreach (var kvp in linkedList)
                {
                    yield return kvp;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var linkedList in _data)
            {
                foreach (var kvp in linkedList)
                {
                    yield return kvp;
                }
            }
        }


        public void Add(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }
    }

    public class DictEnumerator<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>>
    {
        private LinkedList<KeyValuePair<TKey, TValue>>[] _items;
        private int _index = -1;
        private LinkedListNode<KeyValuePair<TKey, TValue>> _currentNode;

        public DictEnumerator(LinkedList<KeyValuePair<TKey, TValue>>[] _items)
        {
            this._items = _items;
        
        }

        public KeyValuePair<TKey, TValue> Current => _currentNode.Value;

        object IEnumerator.Current => _currentNode.Value;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        { 
            if (_currentNode != null && _currentNode.Next != null)
            {
                _currentNode = _currentNode.Next;
                return true;
            }

            while (_currentNode is null)
            {
                _index++;

                if (_index >= _items.Length)
                {
                    return false;
                }

                _currentNode = _items[_index].First;
            }

            return false;
        }

        public void Reset()
        {
            _index = -1;
            _currentNode = null;
        }   
    }
}


