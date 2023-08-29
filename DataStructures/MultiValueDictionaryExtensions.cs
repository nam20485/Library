using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public static class MultiValueDictionaryExtensions
    {
        public static void UnionWith<TKey, TValue>(this MultiValueDictionary<TKey, TValue> @this, MultiValueDictionary<TKey, TValue> other)
            where TKey : notnull
        {
            // add everything from other to this
            foreach (var kvp in other)
            {
                @this.Add(kvp.Key, kvp.Value);
            }
        }

        public static void IntersectWith<TKey, TValue>(this MultiValueDictionary<TKey, TValue> @this, MultiValueDictionary<TKey, TValue> other)
            where TKey : notnull
        {
            //foreach (var kvp in @this)
            //{
            //    var otherValuesForKey = other.GetOrDefault(kvp.Key);
            //    if (otherValuesForKey.Count() == 0)
            //    {
            //        @this.Remove(kvp.Key);
            //    }
            //    else if (!otherValuesForKey.Contains(kvp.Value))
            //    {
            //        @this.Remove(kvp.Key, kvp.Value);
            //    }
            //}

            foreach (var kvp in @this)
            {
                if (!other.GetOrDefault(kvp.Key).Contains(kvp.Value))
                {
                    @this.Remove(kvp.Key, kvp.Value);
                }
            }
        }

        public static void ExceptWith<TKey, TValue>(this MultiValueDictionary<TKey, TValue> @this, MultiValueDictionary<TKey, TValue> other)
            where TKey : notnull
        {          
            // remove everything that is also in the other set
            foreach (var kvp in @this)
            {
                if (other.GetOrDefault(kvp.Key).Contains(kvp.Value))                    
                {
                    @this.Remove(kvp.Key, kvp.Value);
                }               
            }          
        }

        public static void SymmetricExceptWith<TKey, TValue>(this MultiValueDictionary<TKey, TValue> @this, MultiValueDictionary<TKey, TValue> other)
            where TKey : notnull
        {
            // this - intersection + difference of other minus this
            // difference(this, intersection(this, other)) + difference(other, this)
            // differnce(this, other) + difference(other, this)
            // + = union

            foreach (var kvp in @this)
            {
                if (other.GetOrDefault(kvp.Key).Contains(kvp.Value))
                {
                    @this.Remove(kvp.Key, kvp.Value);
                    other.Remove(kvp.Key, kvp.Value);
                }
            }

            foreach (var kvp in other)
            {
                @this.Add(kvp.Key, kvp.Value);
            }
           
            //@this.ExceptWith(other);
            //other.ExceptWith(@this);
            //@this.UnionWith(other);

            //@this.UnionWith(@this.ExceptWith(other), other.ExceptWith(@this);
        }

        public static void DifferenceWith<TKey, TValue>(this MultiValueDictionary<TKey, TValue> @this, MultiValueDictionary<TKey, TValue> other)
            where TKey : notnull
        {
            @this.ExceptWith(other);
        }

        public static void SymmetriDifferenceWith<TKey, TValue>(this MultiValueDictionary<TKey, TValue> @this, MultiValueDictionary<TKey, TValue> other)
            where TKey : notnull
        {            
            @this.SymmetricExceptWith(other);
        }
    }
}
