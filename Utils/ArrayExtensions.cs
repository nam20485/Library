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
            // use Tuples to swap values
            (array[i], array[j]) = (array[j], array[i]);
        }

        public static void Reverse<T>(this T[] array, int start, int length)
        {
            if (start >= 0 && length <= array.Length)
            {
                if (length > 1)
                {
                    // swap first and last index...
                    array.Swap(start, length - 1);
                    // and call recursively on sub-array
                    array.Reverse(start + 1, length - 2);
                }
            }
        }

        public static void Reverse<T>(this T[] array, int start)
        {
            array.Reverse(start, array.Length - start);
        }

        public static void Reverse<T>(this T[] array)
        {
            array.Reverse(0);
        }

        public static T[] ReverseCopy<T>(this T[] array, int start, int length)
        {
            var copy = new T[array.Length];            
            array.CopyTo(copy, 0);
            copy.Reverse(start, length);
            return copy;
        }

        public static T[] ReverseCopy<T>(this T[] array, int start)
        {
            return array.ReverseCopy(start, array.Length - start);
        }

        public static T[] ReverseCopy<T>(this T[] array)
        {
            return array.ReverseCopy(0);
        }
    }
}
