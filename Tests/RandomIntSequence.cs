﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
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

        public int[] Make(int length)
        {
           return this.Take(length).ToArray();
        }

        public static int[] Make(int maxValue, int length)
        {
            return new RandomIntSequence(maxValue).Make(length);
        }

        public IEnumerator<int> GetEnumerator()
        {
            while (true)
            {
                yield return _random.Next(MaxValue);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
