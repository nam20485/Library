//using System.Collections;

namespace Library.DataStructures
{
    public class Stack<TValue> : DsCollectionBase<TValue>
    {
        private readonly List<TValue> _items;        

        public override int Count => _items.Count;

        public Stack()
        {
            _items = new List<TValue>();
        }

        public Stack(IEnumerable<TValue> collection)
            : this()
        {           
            AddRange(collection);
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
            _items.RemoveLast();
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
            var index = Count - 1;
            while (index >= 0)
            {
                yield return _items[index];
            }
        }               
      
        public override IDsCollection<TValue> CopyOf()
        {
            return new Stack<TValue>(_items);
        }

        protected override string GetStringRepresentation()
        {
            return _items.ToString();
        }

        protected override void CopyOnlyItemsTo(TValue[] array, int arrayIndex = 0)
        {
            foreach (var item in _items)
            {
                array[arrayIndex++] = item;
            }
        }
    }
}
