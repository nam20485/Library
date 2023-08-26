using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utils
{       
    public class Operations<TEnum> : IEnumerable<TEnum>
        where TEnum : struct, Enum
    {
        public static readonly TEnum[] TypeValues = Enum.GetValues<TEnum>();

        private static readonly Random _random = new ();

        public IEnumerator<TEnum> GetEnumerator()
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

        public static IEnumerable<TEnum> Types()
        {
            yield return NextType();
        }

        public static TEnum NextType()
        {
            return TypeValues[_random.Next(TypeValues.Length)];
        }      
    }
}
