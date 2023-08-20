using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Queue<TValue> : ICollection<TValue>
    {
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public Queue()
        {

        }

        public Queue(IEnumerable<TValue> collection)
        {
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public void Enqueue(TValue value)
        {
            Add(value);
        }

        public TValue Dequeue()
        {
            throw new NotImplementedException();
        }

        public TValue Peek()
        {
            throw new NotImplementedException();
        }

        public void Add(TValue item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(TValue item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TValue item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
