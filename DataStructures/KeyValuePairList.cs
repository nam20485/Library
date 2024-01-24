using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public class KeyValuePairList<TKey, TValue> : List<KeyValuePair<TKey, TValue>>
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



    }
}
