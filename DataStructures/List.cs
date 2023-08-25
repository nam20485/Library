using System.Collections;
using System.Text;

using Library.Utils;

namespace Library.DataStructures
{
    public class List<TValue> : DsCollectionBase<TValue>, IList<TValue>
    {
        private const int DefaultCapacity = 4;        

        /// <summary>
        /// The TItem's we are holding
        /// </summary>
        private TValue[] _items;

        /// <summary>
        /// Number of actual items being held in the array, i.e. Count
        /// </summary>
        private int _size;

        // defer instantiating new zero-length arrays everytime small Lists are created
        private static readonly TValue[] EmptyArray = Array.Empty<TValue>();
        
        /// <summary>
        /// Instantiates a new empty list.
        /// </summary>
        public List()
            : this(0)
        {            
        }

        /// <summary>
        /// Instantiates a new list with the default capacity.
        /// </summary>
        /// <param name="capacity">Capacity for new list.</param>
        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameof(capacity)}: {capacity}");
            }

            _size = 0;
            _items = EmptyArray;
            // Capacity will create the TItem[]
            //EnsureCapacity(capacity);
            Capacity = capacity;
        }

        /// <summary>
        /// Instantiate a new list and copies all of the items from the given collection in.
        /// </summary>
        /// <param name="collection">IEnumerable to copy elements from.</param>
        public List(IEnumerable<TValue> collection)
            : this(collection.Count())
        {           
            AddRange(collection);      
        }

        // size of array (max amount we can currently hold w/o resizing, not count of actual items in this)
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value != Capacity)
                {
                    if (value > 0)
                    {
                        var newItems = new TValue[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, newItems, _size);                            
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = EmptyArray;
                    }
                }
            }
        }

        //
        //  IList interface implementation
        //
        public TValue this[int index]
        {
            get
            {
                if (index < 0 || index >= _size)
                {
                    throw new ArgumentOutOfRangeException($"{Caller.MemberNameLocation()} - {nameof(index)}: {index} (size = {_size})");
                }
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _size)
                {
                    throw new ArgumentOutOfRangeException($"{Caller.MemberNameLocation()} - {nameof(index)}: {index} (size = {_size})");
                }
                _items[index] = value;                
            }
        }
              
        public int IndexOf(TValue item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }

        public void Insert(int index, TValue item)
        {
            // item can be inserted at the end
            if (index > _size)
            {
                throw new ArgumentOutOfRangeException($"{Caller.MemberNameLocation()} - {nameof(index)}: {index} (size = {_size})");
            }

            EnsureCapacity(_size + 1);

            // shift all elements at >= index up/back one index
            Array.Copy(_items, index, _items, index + 1, _size - index);
            _items[index] = item;
            _size++;
        }

        public void RemoveAt(int index)
        {
            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException($"{Caller.MemberNameLocation()} - {nameof(index)}: {index} (size = {_size})");
            }

            _size--;
            Array.Copy(_items, index + 1, _items, index, _size - index);
        }

        //
        // ICollection interface implementation
        //
        public override int Count => _size;
        public bool IsReadOnly => false;      

        /// <summary>
        /// Add an item to the end of the list.
        /// </summary>
        /// <param name="item"><typeparamref name="TValue"/> to add</param>
        public override void Add(TValue item)
        {
            // increase capacity if necessary
            EnsureCapacity(_size + 1);

            // add the item
            var index = _size;
            _items[index] = item;
            _size++;
        }
        public override void Clear()
        {
            var sizeWas = _size;
            _size = 0;
            if (sizeWas > 0)
            {                
                Array.Clear(_items, 0, _size);
            }
        }

        public override bool Contains(TValue item)
        {
            return IndexOf(item) != -1;
        }

        public bool Contains(TValue value, int upperBound)
        {
            var index = IndexOf(value);
            return 0 <= index && index < upperBound;  // 0 <= index < upperBound
        }

        public bool Remove(TValue item)
        {
            var index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        protected override void CopyOnlyItemsTo(TValue[] array, int arrayIndex = 0)
        {
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }       

        //
        //  Extended methods
        //
        public override void AddRange(IEnumerable<TValue> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            // copy items
            EnsureCapacity(collection.Count());           
            Array.Copy(collection.ToArray(), _items, collection.Count());
            _size = collection.Count();
        }

        public void AddLast(TValue item)
        {
            Insert(Count, item);
        }

        public void AddFirst(TValue item)
        {
            Insert(0, item);
        }
        public void RemoveLast()
        {
            RemoveAt(Count - 1);
        }

        public void RemoveFirst()
        {
            RemoveAt(0);
        }

        public void SwapValues(int index1, int index2)
        {
            (_items[index1], _items[index2]) = (_items[index2], _items[index1]);
        }   

        public enum SortType
        {
            MonotonicallyIncreasing,
            MonotonicallyDecreasing,
            StrictlyIncreasing,
            StrictlyDecreasing,
        }
        
        public bool IsSorted(SortType sortType)
        {
            for (int i = 0; i < _items.Length-1; i++)
            {
                switch (sortType)
                {
                    case SortType.MonotonicallyIncreasing:
                        if (Compare(i, i + 1) > 0)
                        {
                            return false;
                        }
                        break;
                    case SortType.StrictlyIncreasing:
                        if (Compare(i, i + 1) >= 0)
                        {
                            return false;
                        }
                        break;
                    case SortType.MonotonicallyDecreasing:
                        if (Compare(i, i + 1) < 0)
                        {
                            return false;
                        }
                        break;
                    case SortType.StrictlyDecreasing:
                        if (Compare(i, i + 1) <= 0)
                        {
                            return false;
                        }
                        break;
                }                
            }
            return true;
        }

        protected int Compare(int index1, int index2)        
        {
            return List<TValue>.Compare(_items[index1], _items[index2]);
        }

        protected static int Compare(TValue a, TValue b)
        {
            return Comparer<TValue>.Default.Compare(a, b);
        }

        //
        //  IEnumerable<T> implementation
        //      
        public override IEnumerator<TValue> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return _items[i];
            }

            //foreach (var item in _items.Take(Count))
            //{
            //    yield return item;
            //}
        }

        //
        //  Private implementation
        //
        internal void EnsureCapacity(int minRequired)
        {
            if (Capacity < minRequired)
            {
                var newCapacity = Math.Max(Capacity * 2, minRequired);
                if (newCapacity < DefaultCapacity)
                {
                    newCapacity = DefaultCapacity;
                }

                if (newCapacity > Array.MaxLength)
                {
                    newCapacity = Array.MaxLength;
                }

                Capacity = newCapacity;
            }
        }         

        protected override string GetStringRepresentation()
        {
            var sb = new StringBuilder();
            sb.Append('[');
            for (int i = 0; i < Count; i++)
            {
                sb.Append(_items[i]);
                if (i < Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(']');
            sb.Append($" ({Count})");
            return sb.ToString();
        }

        public override IDsCollection<TValue> CopyOf()
        {
            return new List<TValue>(_items.Take(Count));
        }
    }
}
