using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class Set<TValue> : DsCollectionBase<TValue>
    {
        private readonly List<TValue> _items;

        public Set()            
        {
            _items = new List<TValue>();
        }

        public Set(IEnumerable<TValue> collection)
            : this()
        {
            AddRange(collection);
        }

        public override int Count => _items.Count;

        public override void Add(TValue item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
            }
        }

        public override void Clear() => _items.Clear();

        public override bool Contains(TValue item) => _items.Contains(item);

        public override IDsCollection<TValue> CopyOf()
        {
            return new Set<TValue>(_items);
        }

        public override IEnumerator<TValue> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public override TValue Remove()
        {
            return _items.Remove();
        }

        protected override void CopyOnlyItemsTo(TValue[] array, int arrayIndex = 0)
        {
            _items.CopyTo(array, arrayIndex);
        }

        protected override string GetStringRepresentation()
        {
            return _items.ToString();
        }
    }
}
