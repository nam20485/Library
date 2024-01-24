using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    // cannot store the value null!

    public class Set<TValue> : DsCollectionBase<TValue>
        where TValue : notnull
    {
        //private readonly List<TValue> _items;

        //TODO: use a dictionary to take advantage of ContainsKey()'s constant-time lookup to provide O(1) compliexity for Contains()
        private readonly Dictionary<TValue, TValue> _itemsBytItem;

        public Set()            
        {
            //_items = new ();
            _itemsBytItem = new ();
        }

        public Set(IEnumerable<TValue> collection)
            : this()
        {
            AddRange(collection);
        }

        public override int Count => _itemsBytItem.Keys.Count;

        public override void Add(TValue item)
        {
            if (!Contains(item))
            {
                _itemsBytItem[item] = item;
            }

            //if (!_items.Contains(item))
            //{
            //    _items.Add(item);
            //}
        }

        public override void Clear() => _itemsBytItem.Clear();

        public override bool Contains(TValue item) => _itemsBytItem.ContainsKey(item);

        public override IDsCollection<TValue> CopyOf()
        {
            return new Set<TValue>(_itemsBytItem.Keys);
        }

        public override IEnumerator<TValue> GetEnumerator()
        {
            return _itemsBytItem.Keys.GetEnumerator();
        }

        public override TValue Remove()
        {
            if (! _itemsBytItem.Keys.Any())
            {
                throw new InvalidOperationException("");
            }

            var item = _itemsBytItem.Keys.Last();
            _itemsBytItem.Remove(item);
            return item;
            //return _items.Remove();
        }

        protected override void CopyOnlyItemsTo(TValue[] array, int arrayIndex = 0)
        {
            _itemsBytItem.Keys.CopyTo(array, arrayIndex);
        }

        protected override string GetStringRepresentation()
        {
            return new List<TValue>(_itemsBytItem.Keys).ToString();
        }
    }
}
