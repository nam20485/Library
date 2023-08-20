using System.Collections;

using Library.Utils;

namespace Library.DataStructures
{
    public class List<TItem> : IList<TItem>, IReadOnlyList<TItem>
    {
        private const int DefaultCapacity = 4;        

        /// <summary>
        /// The TItem's we are holding
        /// </summary>
        private TItem[] _items;

        /// <summary>
        /// Number of actual items being held in the array, i.e. Count
        /// </summary>
        private int _size;
        
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
            _size = 0;                        
            _items = Array.Empty<TItem>();
            // Capacity will create the TItem[]
            Capacity = capacity;
        }

        /// <summary>
        /// Instantiate a new list and copies all of the items from the given collection in.
        /// </summary>
        /// <param name="collection">IEnumerable to copy elements from.</param>
        public List(IEnumerable<TItem> collection)
            : this(collection.Count())
        {
            // copy items
            Array.Copy(collection.ToArray(), _items, collection.Count());            
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
                        var newItems = new TItem[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, newItems, _size);
                            _items = newItems;
                        }
                    }
                    else
                    {
                        _items = Array.Empty<TItem>();
                    }
                }
            }
        }

        public TItem this[int index]
        {
            get
            {
                if (index < _size)
                {
                    return _items[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException($"{index} (size = {_size})");
                }
            }
            set
            {
                Insert(index, value);
            }
        }

        public int Count => _size;

        public bool IsReadOnly => false;

        /// <summary>
        /// Add an item to the end of the list.
        /// </summary>
        /// <param name="item"><typeparamref name="TItem"/> to add</param>
        public void Add(TItem item)
        {
            // increase capacity if necessary
            EnsureCapacity(_size+1);

            // add the item
            var index = _size;
            _items[index] = item;
            _size++;
        }

        private void EnsureCapacity(int minRequired)
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
      
        public void Clear()
        {
            var sizeWas = _size;
            _size = 0;
            if (sizeWas > 0)
            {                
                Array.Clear(_items, 0, _size);
            }
        }

        public bool Contains(TItem item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(TItem[] array, int arrayIndex)
        {            
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }
       
        public int IndexOf(TItem item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }

        public void Insert(int index, TItem item)
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

        public bool Remove(TItem item)
        {
            var index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index >= _size)
            {
                throw new ArgumentOutOfRangeException($"{Caller.MemberNameLocation()} - {nameof(index)}: {index} (size = {_size})");
            }

            _size--;
            Array.Copy(_items, index+1, _items, index, _size-index);
        }

        //
        //  IEnumerable<T> implementation
        // 
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();   
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            foreach (var item in _items)
            {
                yield return item;
            }
        }
    }
}
