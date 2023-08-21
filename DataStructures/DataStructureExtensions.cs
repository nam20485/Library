using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataStructures
{
    public static class DataStructureExtensions
    {     
        public static TSource[] ToArray<TSource>(this IDsCollection<TSource> source)
        {
            return source.ToArray();
        }

        public static List<TSource> ToList<TSource>(this IDsCollection<TSource> source)
        {
            return new List<TSource>(source.ToArray());
            //return new List<TSource>(source);
        }      
    }
}
