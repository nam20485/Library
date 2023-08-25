using System.Collections;

namespace Library.DataStructures
{
    public class Queue<TValue> : DsCollectionBase<TValue>
    {
        private readonly List<TValue> _items;

        public override int Count => _items.Count;        

        public Queue()
        {
            _items = new List<TValue>();
        }

        public Queue(IEnumerable<TValue> collection)
            : this()
        {           
            AddRange(collection);
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
     
        public TValue Peek()
        {
            if (IsEmpty())
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return _items[0];
        }

        public override void Add(TValue item)
        {
            _items.Add(item);
        }

        public override void Clear()
        {
            _items.Clear();
        }

        public override bool Contains(TValue item)
        {
            return _items.Contains(item);
        }       

        public override IEnumerator<TValue> GetEnumerator()
        {
            // TODO: should we make this a destructive iterator?
            foreach (var item in _items)
            {
                yield return item;
            }
        }               

        public override IDsCollection<TValue> CopyOf()
        {
            return new Queue<TValue>(_items);
        }

        protected override string GetStringRepresentation()
        {
            return _items.ToString();
        }

        protected override void CopyOnlyItemsTo(TValue[] array, int arrayIndex = 0)
        {
            foreach (var item in this)
            {
                array[arrayIndex++] = item;
            }
        }
    }
}
