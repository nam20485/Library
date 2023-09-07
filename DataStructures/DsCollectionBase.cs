using System.Collections;

namespace Library.DataStructures
{
    public abstract class DsCollectionBase<TValue> : IDsCollection<TValue>
    {
        //protected DsCollectionBase(IEnumerable<TValue> collection)
        //{
        //    AddRange(collection);
        //}

        //
        //  Abstract members all IDsCollection inheritors must implement
        //
        public abstract int Count { get; }       

        public abstract void Add(TValue item);
        public abstract bool Contains(TValue item);
        public abstract void Clear();
        public abstract TValue Remove();

        //TODO: add Peek() to all collections
        //public abstract TValue Peek();

        public abstract IEnumerator<TValue> GetEnumerator();
        public abstract IDsCollection<TValue> CopyOf();

        protected abstract string GetStringRepresentation();
        protected abstract void CopyOnlyItemsTo(TValue[] array, int arrayIndex = 0);

        //
        //  Shared implementations built from the abstract members
        //
        public bool IsEmpty() => Count == 0;
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public override string ToString() => GetStringRepresentation();
        public List<TValue> ToList() => new (ToArray());
        public Heap<TValue> ToHeap() => new (ToArray());
        public Heap<TValue> ToHeap(IComparer<TValue> comparer) => new (ToArray(), comparer);
        public MinHeap<TValue> ToMinHeap() => new (ToArray());
        public Stack<TValue> ToStack() => new (ToArray());
        public Queue<TValue> ToQueue() => new (ToArray());
        
        public void CopyTo(TValue[] array, int arrayIndex = 0) => CopyOnlyItemsTo(array, arrayIndex);

        public virtual void AddRange(IEnumerable<TValue> collection)
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

        public TValue[] ToArray()
        {
            var newArray = new TValue[Count];
            CopyOnlyItemsTo(newArray);
            return newArray;
        }       
    }
}
