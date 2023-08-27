using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utils
{
    public static class ArrayExtensions
    {
        public static void Swap<T>(this T[] array, int i, int j)
        {
            (array[i], array[j]) = (array[j], array[i]);
        }
    }
}
