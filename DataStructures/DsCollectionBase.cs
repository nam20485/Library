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
        public abstract int Count { get; }       

        public abstract void Add(TValue item);         

        public abstract IEnumerator<TValue> GetEnumerator();

        protected abstract string GetStringRepresentation();

        protected abstract void CopyOnlyItemsTo(TValue[] array, int arrayIndex = 0);

        public bool IsEmpty() => Count == 0;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => GetStringRepresentation();

        public List<TValue> ToList() => new (ToArray());

        public /*virtual*/ void CopyTo(TValue[] array, int arrayIndex = 0)
        {
            CopyOnlyItemsTo(array, arrayIndex);
        }

        public virtual void AddRange(IEnumerable<TValue> collection)
        {
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
