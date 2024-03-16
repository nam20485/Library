using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class KeyValuePairList<TKey, TValue> : System.Collections.Generic.List<KeyValuePair<TKey, TValue>>
        where TKey : notnull
    {
        public KeyValuePairList()
            : base()
        {
        }

        public KeyValuePairList(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            : base(collection)
        {
        }

        public static System.Collections.Generic.List<KeyValuePair<TKey, TValue>> CreateRandom(Dictionary<TKey, System.Collections.Generic.List<TValue>> seedValues, int length)
        {
            var random = new Random();

            //var kvpList = new KeyValuePairList<string, string>[length];
            var kvpList = new System.Collections.Generic.List<KeyValuePair<TKey, TValue>>();

            while (kvpList.Count < length)  // make sure we get length unique items (taking into account duplicates that are thrown away)
            //for (int i = 0; i < length; i++)
            {
                var randomKey = seedValues.Keys.ElementAt(random.Next(seedValues.Keys.Count));
                var randomValue = seedValues[randomKey].ElementAt(random.Next(seedValues[randomKey].Count));

                var randomKvp = new KeyValuePair<TKey, TValue>(randomKey, randomValue);

                if (!kvpList.Contains(randomKvp))
                {
                    kvpList.Add(randomKvp);
                }
            }

            return kvpList;
        }
    }
}
