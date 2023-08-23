using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public abstract class DsCollectionBase<TValue> : IDsCollection<TValue>
    {
        //
        //  Abstract members all IDsCollection inheritors must implement
        //
        public abstract int Count { get; }       

        public abstract void Add(TValue item);
        public abstract bool Contains(TValue item);
        public abstract void Clear();        

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
        public Heap<TValue> ToHeap(IComparer<TValue> comparer) => new(ToArray(), comparer);
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
