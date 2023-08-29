using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public interface IMultiValueDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        /// <summary>
        /// Retrieves values for given key, if present. Throws <see cref="KeyNotFoundException"/> if key is not present. 
        /// </summary>
        /// <param name="key"><typeparamref name="TKey"/> to retrieve values for.</param>
        /// <returns>IEnumerable<typeparamref name="TValue"/> of any values associated with given key.</returns>
        IEnumerable<TValue> Get(TKey key);

        /// <summary>
        /// Retrieves values for given key, if present. If not present returns default.
        /// </summary>
        /// <param name="key"><typeparamref name="TKey"/> to retrieve values for.</param>
        /// <returns>IEnumerable<typeparamref name="TValue"/> of any values associated with given key if present. If not present, return default.</returns>
        IEnumerable<TValue> GetOrDefault(TKey key);

        /// <summary>
        /// Adds the given value to the given key. If value with given key already exists, it is not added.
        /// </summary>
        /// <param name="key"><typeparamref name="TKey"/> key to associate value with.</param>
        /// <param name="value"><typeparamref name="TValue"/> to add and associate to given key.</param>
        /// <returns>True if collection was modified (i.e. key and value pair already existed), false otherwise.</returns>
        bool Add(TKey key, TValue value);       
        
        /// <summary>
        /// Removes all values associated with given key, if present.
        /// </summary>
        /// <param name="key"><typeparamref name="TKey"/> to remvoe values for.</param>
        /// <exception cref="KeyNotFoundException">Provided key is not present.</exception>
        void Remove(TKey key);

        /// <summary>
        /// Removes a given value, if present.
        /// </summary>
        /// <param name="key">Key to remove value from.</param>
        /// <param name="value">Value to remove.</param>
        void Remove(TKey key, TValue value);

        /// <summary>
        /// Clear all keys and values from the dictionary.
        /// </summary>
        void Clear();

        /// <summary>
        /// Returns a "flattened" collection of all keys and their values in 
        /// KeyValuePair<typeparamref name="TKey"/>, <typeparamref name="TValue"/> form, 
        /// with one KeyValuePair<typeparamref name="TKey"/>, <typeparamref name="TValue"/> 
        /// for each key and value combination present in dictionary.
        /// </summary>
        // /// <returns>IEnumerabl<KeyValuePair<<typeparamref name="TKey"/>, <typeparamref name="TValue"/>>> of all key-value pairs present in dictionary.></returns>
        IEnumerable<KeyValuePair<TKey, TValue>> Flatten();
      
        /// <summary>
        /// Returns whether given key is present and contains values in this dictionary.
        /// </summary>
        /// <param name="key"><typeparamref name="TKey"/> to search dictionary for.</param>
        /// <returns>True if dictionary contains key, false otheerwise.</returns>
        //bool ContainsKey(TKey key);

        /// <summary>
        /// Determines whether given key and value are present in this dictionary.
        /// </summary>
        /// <param name="key"><typeparamref name="TKey"/> to search for.</param>
        /// <param name="value"><typeparamref name="TValue"/> to search for.</param>
        /// <returns>True if given key and value are present in dictionary, false if either key or value are not present.</returns>
        //bool ContainsValue(TKey key, TValue value);
    }
}
