using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hashtable
{
    class HTable<T> : IEnumerable<T>
    {
        private Item<T>[] items;

        public HTable(int size)
        {
            items = new Item<T>[size];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = new Item<T>(i);
            
            }
        }

        public void AddItem(T item)
        {
            var key = GetHash(item);
            items[key].Nodes.Add(item);
            
        
        }
        private int GetHash(T item)
        {
            return item.GetHashCode() % items.Length;

        }

     
        public bool Search(T item)
        {
            var key = GetHash(item);
            return items[key].Nodes.Contains(item);

        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

       

    }

    public class HashEnumerator<T> : IEnumerator<T>
    {

        private Item<T>[] items;
        private int iterator = -1;

        public HashEnumerator(Item<T>[] items)
        {
            this.items = items;
        
        }



        public T Current => items[iterator];

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            iterator++;
            return iterator< items.Length;
        }

        public void Reset()
        {
           iterator = -1;
        }
    }

}
