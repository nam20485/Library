using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Utils;

namespace Library.Tests
{
    public class IntIDsCollectionTestData : IDsCollectionsTestData<int>
    {
        protected override int[][] Inputs => new[]
            {
                new [] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 },
                //Array.Empty<int>(),
                new [] { 0 },
                new [] { 0, 1 },
                new [] { 0, 1, 2 },
                new [] { 0, 1, 2, 3 }
            };
    }

    public class RandomIntArraysTestData : IEnumerable<object[]>
    {
        private const int TestDatasCount = 100;
        private const int TestDataLength = 100;
        private const int MaxValue = 100;

        private readonly RandomIntSequence _sequence = new(MaxValue);

        public IEnumerator<object[]> GetEnumerator()
        {
            for (int i = 0; i < TestDatasCount; i++)
            {
                yield return new object[] { _sequence.Array(TestDataLength) };
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class RandomIntIDsCollectionTestData : IDsCollectionsTestData<int>
    {
        private const int TestDatasCount = 10;
        private const int TestDataLength = 100;
        private const int MaxValue = 100;

        private readonly RandomIntSequence _sequence = new(MaxValue);

        protected override int[][] Inputs
        {
            get
            {
                var testDatas = new int[TestDatasCount][];
                
                for (int i = 0; i < TestDatasCount; i++)
                {
                    testDatas[i] = _sequence.Array(TestDataLength);
                }

                return testDatas;
            }
        }      
    }
}
