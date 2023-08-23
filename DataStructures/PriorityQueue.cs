using System.Runtime.Serialization;

namespace Library.DataStructures
{
    public class PriorityQueue<TValue, TKey> : Heap<PriorityQueue<TValue, TKey>.Node>
    {
        public PriorityQueue()
            : base()
        {
        }

        public PriorityQueue(IComparer<Node> comparer)
            : base(comparer)
        {           
        }

        public PriorityQueue(IEnumerable<Node> collection)
            : base(collection)
        {
        }

        public PriorityQueue(IEnumerable<Node> collection, IComparer<Node> comparer)
            : base(collection, comparer)
        {
        }

        public void Insert(TValue value, TKey key)
        {
            Insert(new Node(value, key));
        }

        public void Insert(Node newNode)
        {            
            _heapSize++;
            var index = _heapSize - 1;
            while (index > 0 && _comparer.Compare(_items[ParentIndex(index)], newNode) < 0)
            {
                _items[index] = _items[ParentIndex(index)];
                index = ParentIndex(index);
            }
            _items[index] = newNode;
        }

        public TValue Peek()
        {
            if (_heapSize < 1)
            {
                // TODO: better name for "heap underflow" exception
                throw new InvalidPriorityQueueException("Heap underflow");
            }

            return _items[0].Value;
        }

        public TValue Remove()
        {
            var max = Peek();
            _items[0] = _items[_heapSize - 1];
            _heapSize--;
            Heapify(0);
            return max;
        }

        public class Node
        {
            public TValue Value { get; }
            public TKey Key { get; }
            
            public Node(TValue value, TKey key)
            {
                Value = value;
                Key = key;
            }
        }
    }

    [Serializable]
    public class InvalidPriorityQueueException : Exception
    {
        public InvalidPriorityQueueException()
        {
        }

        public InvalidPriorityQueueException(string? message) : base(message)
        {
        }

        public InvalidPriorityQueueException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidPriorityQueueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
