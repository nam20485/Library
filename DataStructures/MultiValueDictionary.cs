using System.Collections;

namespace Library.DataStructures
{
    public class MultiValueDictionary<TKey, TValue> : IMultiValueDictionary<TKey, TValue>
        where TKey : notnull
    {
        private readonly Dictionary<TKey, System.Collections.Generic.HashSet<TValue>> _valuesByKey;

        public MultiValueDictionary()
        {
            _valuesByKey = new ();
        }

        public MultiValueDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            : this()
        {
            foreach (var kvp in collection)
            {
                Add(kvp.Key, kvp.Value);
            }
        }

        public bool Add(TKey key, TValue value)
        {
            if (! _valuesByKey.ContainsKey(key))
            {
                _valuesByKey[key] = new System.Collections.Generic.HashSet<TValue>();               
            }

            var values = _valuesByKey[key];
            if (! values.Contains(value))
            {
                values.Add(value);
                return true;
            }        

            return false;
        }

        public void Clear()
        {
            _valuesByKey.Clear();
        }             

        public IEnumerable<TValue> Get(TKey key)
        {
            if (! _valuesByKey.ContainsKey(key))
            {
                throw new KeyNotFoundException($"Key {key} not found.");
            }

            return _valuesByKey[key];
        }      

        public IEnumerable<TValue> GetOrDefault(TKey key)
        {
            if (!_valuesByKey.ContainsKey(key))
            {
                // can't use default(IEnumerable<TValue>) b/c default(IEnumerable<string>) is null
                //return default;
                return new List<TValue>();
            }
            else
            {
                return _valuesByKey[key];
            }
        }

        public void Remove(TKey key)
        {
            _valuesByKey.Remove(key);            
            //return _valuesByKey.Remove(key);
        }

        public void Remove(TKey key, TValue value)
        {
            if ( _valuesByKey.ContainsKey(key))
            {
                _valuesByKey[key].Remove(value);
            }
        }      

        public IEnumerable<KeyValuePair<TKey, TValue>> Flatten()
        {
            var list = new List<KeyValuePair<TKey, TValue>>();

            foreach (var kvp in _valuesByKey)
            {
                foreach (var value in kvp.Value)
                {
                    list.Add(new KeyValuePair<TKey, TValue> (kvp.Key, value));
                }
            }

            return list;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var kvp in Flatten())
            {
                yield return kvp;
            }
        }
   
        //public bool ContainsValue(TKey key, TValue value)
        //{
        //    return GetOrDefault(key).Contains(value);
        //}

        //public bool ContainsKey(TKey key)
        //{
        //    return _valuesByKey.ContainsKey(key);
        //}

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }      
    }
}
