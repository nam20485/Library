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

        public static void Reverse<T>(this T[] array, int start, int length)
        {
            if (start >= 0 && length <= array.Length)
            {
                if (length > 1)                
                {
                    array.Swap(start, length - 1);                   
                    array.Reverse(start + 1, length - 2);                    
                }
            }
        }

        public static void Reverse<T>(this T[] array, int start)
        {
            array.Reverse(start, array.Length-start);
        }

        public static void Reverse<T>(this T[] array)
        {
            array.Reverse(0);
        }
    }
}
