using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Heap<TValue> : DsCollectionBase<TValue>
    {
        protected readonly List<TValue> _items;
        protected int _heapSize = 0;

        protected readonly IComparer<TValue> _comparer;

        public override int Count => _items.Count;

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

        // shift right by 1 to divide by 2, shift left by 1 to multiply by 2
        protected static int ParentIndex(int index) => (index - 1) >> 1;
        protected static int LeftChildIndex(int index) => (index << 1) + 1;
        protected static int RightChildIndex(int index) => LeftChildIndex(index) + 1;

        protected void Heapify(int index)
        {            
            var l = LeftChildIndex(index);
            var r = RightChildIndex(index);

            // find largest between _items at indices l, r, & index
            int largest;
            if (l < _heapSize && _comparer.Compare(_items[l], _items[index]) > 0)                
            {
                largest = l;
            }
            else
            {
                largest = index;
            }
            if (r < _heapSize && _comparer.Compare(_items[r], _items[largest]) > 0)
            {
                largest = r;
            }
            // swap largest and index and then call Heapify on largest
            if (largest != index)
            {
                // use Tuples to swap
                (_items[index], _items[largest]) = (_items[largest], _items[index]);
                Heapify(largest);
            }
        }

        protected void BuildHeap()
        {
            _heapSize = _items.Count;
            // starting with last non-leaf node
            for (int i = _items.Count/2-1; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        public void Sort()
        {
            BuildHeap();
            for (int i = _items.Count-1; i > 0; i--)
            {
                // use Tuples to swap
                (_items[0], _items[i]) = (_items[i], _items[0]);
                _heapSize--;
                Heapify(0);
            }
        }

        /// <summary>
        /// Returns a new array that has been heap sorted.
        /// </summary>
        /// <param name="items"><see cref="IEnumerable&lt;TValue&gt;"/>&lt;<typeparamref name="TValue"/>&gt; of items to sort.</param>
        /// <returns>A new <typeparamref name="TValue"/>[] that has been heap sorted.</returns>
        public static TValue[] HeapSort(IEnumerable<TValue> items)
        {
            return SortedHeapArray(new Heap<TValue>(items));
        }

        /// <summary>
        /// Returns a new array that has been heap sorted using the specified IComparer.
        /// </summary>
        /// <param name="items"><see cref="IEnumerable&lt;TValue&gt;"/>&lt;<typeparamref name="TValue"/>&gt; of items to sort.</param>        
        /// <param name="comparer">IComparer&lt;<typeparamref name="TValue"/>&gt; to compare items when sorting.</param>
        /// <returns>A new <typeparamref name="TValue"/>[] that has been heap sorted.</returns>
        public static TValue[] HeapSort(IEnumerable<TValue> items, IComparer<TValue> comparer)
        {
            return SortedHeapArray(new Heap<TValue>(items, comparer));
        }

        private static TValue[] SortedHeapArray(Heap<TValue> heap)
        {
            heap.Sort();
            return heap.ToArray();
        }

        public override IEnumerator<TValue> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
      
        protected override string GetStringRepresentation()
        {
            return _items.ToString();
        }

        protected override void CopyOnlyItemsTo(TValue[] array, int arrayIndex = 0)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public override void Add(TValue item)
        {
            _items.Add(item);
            _heapSize++;
            Heapify(_items.Count-1);
        }

        public override bool Contains(TValue item)
        {
            return _items.Contains(item);
        }

        public override void Clear()
        {
            _items.Clear();
        }
    }
}
