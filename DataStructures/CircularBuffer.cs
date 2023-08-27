using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class CircularBuffer<TValue> : IDsCollection<TValue>
    {
        private readonly TValue[] _items;
        private int _size;

        private int _readIndex;
        private int _writeIndex;

        public int Capacity => _items.Length;
       
        public CircularBuffer(int capacity)
        {
            _items = new TValue[capacity];
            _size = 0;
            _readIndex = 0;
            _writeIndex = 0;
        }

        public CircularBuffer(IEnumerable<TValue> collection)
            : this(collection.Count())
        {
            AddRange(collection);
        }

        public int Count => _size;

        public void Add(TValue item)
        {
            if (_writeIndex == Capacity)
            {
                _writeIndex = 0;
            }

            _items[_writeIndex] = item;
            _writeIndex++;            
        }

        public void AddRange(IEnumerable<TValue> collection)
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

        public IDsCollection<TValue> CopyOf()
        {
            throw new NotImplementedException();
        }

        public void CopyTo(TValue[] array, int arrayIndex = 0)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool IsEmpty()
        {
            throw new NotImplementedException();
        }

        public TValue Remove()
        {
            throw new NotImplementedException();
        }

        public TValue[] ToArray()
        {
            throw new NotImplementedException();
        }

        public Heap<TValue> ToHeap()
        {
            throw new NotImplementedException();
        }

        public Heap<TValue> ToHeap(IComparer<TValue> comparer)
        {
            throw new NotImplementedException();
        }

        public List<TValue> ToList()
        {
            throw new NotImplementedException();
        }

        public MinHeap<TValue> ToMinHeap()
        {
            throw new NotImplementedException();
        }

        public Queue<TValue> ToQueue()
        {
            throw new NotImplementedException();
        }

        public Stack<TValue> ToStack()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
