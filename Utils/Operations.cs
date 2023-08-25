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
            yield return NextType();
        }

        public static Type NextType()
        {
            return TypeValues[_random.Next(TypeValues.Length)];
        }

        public enum Type
        { 
            Clear,
            Add,           
            AddRange,            
            Contains,           
            IsEmpty,
            
            CopyTo,
            CopyOf,
            
            ToArray,
            ToList,
            ToHeap,
            ToMinHeap,
            ToQueue,
            ToStack,

            ToArrayOfT,
            ToListOfT,
            ToHeapOfT,
            ToMinHeapOfT,
            ToQueueOfT,
            ToStackOfT,
        }

    }
}
