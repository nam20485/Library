using System.Collections;

namespace Library.DataStructures
{
    public class Queue<TValue> : IEnumerable<TValue>
    {
        private readonly List<TValue> _items;

        public int Count => _items.Count;        

        public Queue()
        {
            _items = new List<TValue>();
        }

        public Queue(IEnumerable<TValue> collection)
            : this()
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            AddRange(collection);
        }

        private void AddRange(IEnumerable<TValue> collection)
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

        public void Enqueue(TValue value)
        {
            Add(value);
        }

        public TValue Dequeue()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var item = Peek();
            _items.RemoveFirst();
            return item;
        }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public TValue Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items[0];
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
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
        }

        public IEnumerator<TValue> GetEnumerator()
        {
            // TODO: should we make this a destructive iterator?
            foreach (var item in _items)
            {
                yield return item;
            }
        }   

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
