using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utils
{
    public class Operations : IEnumerable<Operations.Type>
    {
        public static readonly Type[] TypeValues = Enum.GetValues<Type>();

        private static readonly Random _random = new Random();

        public IEnumerator<Type> GetEnumerator()
        {
            var random = new Random();

            while (true)
            {
                yield return TypeValues[random.Next(TypeValues.Length)];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static IEnumerable<Type> Types()
        {
            yield return Next();
        }

        public static Type Next()
        {
            return TypeValues[_random.Next(TypeValues.Length)];
        }

        public enum Type
        { 
            Clear,
            Add,           
            AddRange,
            ToString,
            Contains,
            CopyTo,
            IsEmpty,
            CopyOf,
            ToArray,
            ToList,
            ToHeap,
            ToQueue,
            ToStack
        }

    }
}
