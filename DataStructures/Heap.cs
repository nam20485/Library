using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Heap<TValue> : IEnumerable<TValue>
    {
        protected readonly List<TValue> _items;
        protected int _heapSize = 0;

        protected readonly IComparer<TValue> _comparer;        

        public Heap()
            : this(Comparer<TValue>.Default)
        {           
        }

        public Heap(IComparer<TValue> comparer)
        {
            _items = new List<TValue>();
            _heapSize = 0;

            _comparer = comparer;            
        }

        public Heap(IEnumerable<TValue> collection)            
        {
            _items = new List<TValue>(collection);
            _heapSize = 0;
            _comparer = Comparer<TValue>.Default;

            BuildHeap();
        }

        public Heap(IEnumerable<TValue> collection, IComparer<TValue> comparaer)
            : this(comparaer)
        {
            _items = new List<TValue>(collection);
            _heapSize = 0;
            _comparer = comparaer;

            BuildHeap();
        }

        protected static int ParentIndex(int index) => (index - 1) / 2;
        protected static int LeftChildIndex(int index) => index * 2;
        protected static int RightChildIndex(int index) => (index * 2) + 1;

        protected void Heapify(int index)
        {
            int largest;
            var l = LeftChildIndex(index);
            var r = RightChildIndex(index);

            // find largest
            if (l <= _heapSize && _comparer.Compare(_items[l], _items[index]) > 0)                
            {
                largest = l;
            }
            else
            {
                largest = index;
            }
            if (r <= _heapSize && _comparer.Compare(_items[r], _items[largest]) > 0)
            {
                largest = r;
            }
            // swap largest and index and then call Heapify on largest
            if (largest != index)
            {
                (_items[index], _items[largest]) = (_items[largest], _items[index]);
                Heapify(largest);
            }
        }

        protected void BuildHeap()
        {
            _heapSize = _items.Count;
            for (int i = _items.Count/2-1; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public void Sort()
        {
            BuildHeap();
            for (int i = _items.Count-1; i >= 1; i--)
            {
                (_items[0], _items[i]) = (_items[i], _items[0]);
                _heapSize--;
                Heapify(0);
            }
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return _items.ToString();
        }
    }
}
