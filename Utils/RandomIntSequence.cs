using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Utils
{
    public class RandomIntSequence : IEnumerable<int>
    {        
        public int MaxValue { get; }

        private readonly Random _random;

        public RandomIntSequence(int maxValue)
        {            
            MaxValue = maxValue;
            _random = new Random();
        }

        public int Next()
        {
            return _random.Next(MaxValue);
        }

        public int[] Array(int length)
        {
           return this.Take(length).ToArray();
        }

        public static int[] Array(int maxValue, int length)
        {
            return new RandomIntSequence(maxValue).Array(length);
        }

        public static int Next(int maxValue)
        { 
            return new RandomIntSequence(maxValue).Next();
        }

        public IEnumerator<int> GetEnumerator()
        {
            while (true)
            {
                yield return Next();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
