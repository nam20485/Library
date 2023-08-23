using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Heap<TValue> : DsCollectionBase<TValue>
    {
        protected readonly List<TValue> _items;
        protected int _heapSize = 0;

        protected readonly IComparer<TValue> _comparer;

        // TODO: change to => _heapSize
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
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            _items = new List<TValue>(collection);
            _heapSize = 0;
            _comparer = Comparer<TValue>.Default;

            BuildHeap();
        }

        public Heap(IEnumerable<TValue> collection, IComparer<TValue> comparaer)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            _comparer = comparaer ?? throw new ArgumentNullException(nameof(comparaer));

            _items = new List<TValue>(collection);
            _heapSize = 0;            

            BuildHeap();
        }

        // shift right by 1 to divide by 2, shift left by 1 to multiply by 2
        protected static int ParentIndex(int index) => (index - 1) >> 1;
        protected static int LeftChildIndex(int index) => (index << 1) + 1;
        protected static int RightChildIndex(int index) => LeftChildIndex(index) + 1;

        protected TValue ParentValue(int index)
        {
            if (index > 0)
            {
                return _items[ParentIndex(index)];
            }
            else
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        protected TValue LeftChildValue(int index)
        {
            var l = LeftChildIndex(index);
            if (l < _heapSize)
            {
                return _items[LeftChildIndex(index)];
            }
            else
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        protected TValue RightChildValue(int index)
        {
            var r = RightChildIndex(index);
            if (r < _heapSize)
            {
                return _items[RightChildIndex(index)];
            }
            else
            {
                throw new IndexOutOfRangeException(nameof(index));
            }
        }

        protected void Heapify(int index)   // i.e. "MoveDown"
        {            
            var l = LeftChildIndex(index);
            var r = RightChildIndex(index);

            // find largest between _items at indices l, r, & index
            int largest = index;
            if (l < _heapSize && _comparer.Compare(_items[l], _items[index]) > 0)                
            {
                largest = l;
            }
            if (r < _heapSize && _comparer.Compare(_items[r], _items[largest]) > 0)
            {
                largest = r;
            }
            // swap largest and index and then call Heapify on largest
            if (largest != index)
            {
                // use Tuples to swap
                _items.SwapValues(index, largest);
                Heapify(largest);
            }
        }

        protected void BuildHeap()  // i.e. "Heapify"
        {
            _heapSize = _items.Count;
            // starting with last non-leaf node
            //var start = _items.Count / 2 - 1;
            var start = ParentIndex(_items.Count - 1);
            for (int i = start; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        protected bool HeapProperty(int index)
        {
            return _comparer.Compare(_items[ParentIndex(index)], _items[index]) >= 0;
        }

        public bool IsLeaf(int index)
        {
            //if (index > _items.Count / 2 - 1)
            //{
            //    return true;
            //}
            if (LeftChildIndex(index) >= _heapSize &&
                RightChildIndex(index) >= _heapSize)
            {
                return true;
            }
            return false;
        }

        public bool IsParent(int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            //return index <= _items.Count / 2 - 1;
            if (LeftChildIndex(index) >= _heapSize && RightChildIndex(index) >= _heapSize)
            {
                return true;
            }
            return false;
        }

        public bool IsHeap(int index = 0)
        {
            if (IsLeaf(index))
            {
                return true;
            }

            var l = LeftChildIndex(index);
            var r = RightChildIndex(index);
            if (_comparer.Compare(_items[index], _items[l]) >= 0)
            {
                if (_comparer.Compare(_items[index], _items[r]) >= 0)
                {
                    return IsHeap(l) && IsHeap(r);
                }
            }

            return false;
        }

        public bool SatisfiesHeapProprty(int index)
        {
            //for (int i = 0; i < ParentIndex(_items.Count/2-1); i++)
            for (int i = index; i <= _items.Count/2-1; i++)
            {
                if (!HeapProperty(i))
                {
                    return false;
                }
            }
            return true;
        }

        public void Sort()
        {
            BuildHeap();
            for (int i = _items.Count-1; i > 0; i--)
            {                
                _items.SwapValues(0, i);
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
            Heapify(ParentIndex(_items.Count - 1));
            //BuildHeap();
        }

        public override void AddRange(IEnumerable<TValue> collection)
        {            
            _items.AddRange(collection);
            BuildHeap();
        }

        public override bool Contains(TValue item)
        {
            return _items.Contains(item);
        }

        public override void Clear()
        {
            _items.Clear();
        }

        public override IDsCollection<TValue> CopyOf() => new Heap<TValue>(_items);
    }
}
