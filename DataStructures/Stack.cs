using System.Collections;

namespace Library.DataStructures
{
    public class Stack<TValue> : IEnumerable<TValue>
    {
        private readonly List<TValue> _items;        

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        public Stack()
        {
            _items = new List<TValue>();
        }

        public Stack(IEnumerable<TValue> collection)
            : this()
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            AddRange(collection);
        }      

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Push(TValue value)
        {
            Add(value);
        }

        public TValue Pop()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            var item = Peek();
            _items.RemoveAt(Count - 1);
            return item;            
        }

        public TValue Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return _items[Count - 1];            
        }

        public void Add(TValue item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(TValue item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(TValue[] array, int arrayIndex)
        {
            foreach (var item in _items)
            {
                array[arrayIndex++] = item;
            }
        }      

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            var index = Count - 1;
            while (index >= 0)
            {
                yield return _items[index];
            }
        }

        public void AddRange(IEnumerable<TValue> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            foreach (var item in collection)
            {
                Add(item);
            }
        }

    }
}
