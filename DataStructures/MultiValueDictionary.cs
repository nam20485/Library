using System.Collections.Generic;

namespace Library.DataStructures
{
    public class MultiValueDictionary<TKey, TValue/*, TValueCollection*/> : IMultiValueDictionary<TKey, TValue>
        where TKey: notnull
        //where TValueCollection : ICollection<TValue>, new()
    {
        private readonly Dictionary<TKey, System.Collections.Generic.HashSet<TValue>> _valuesByKey;

        public MultiValueDictionary()
        {
            _valuesByKey = new ();
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
                return default;
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

        public void SixthMethod()
        {
            // void Remove(TKey, TValue) ???
            throw new NotImplementedException();
        }

        public IEnumerable<KeyValuePair<TKey, TValue>> Flatten()
        {
            foreach (var kvp in _valuesByKey)
            {
                foreach (var value in kvp.Value)
                {
                    yield return new KeyValuePair<TKey, TValue> (kvp.Key, value);
                }
            }
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Flatten().GetEnumerator();
        }
   
        public bool ContainsValue(TKey key, TValue value)
        {
            return GetOrDefault(key).Contains(value);
        }

        public bool ContainsKey(TKey key)
        {
            return _valuesByKey.ContainsKey(key);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
