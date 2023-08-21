using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.DataStructures;

namespace Library.Tests
{
    public class HeapTests
    {
        [Fact]
        public void Test_Heap()
        {
            var testCases = new[]
            {
                new [] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 }
            };

            foreach (var testCase in testCases)
            {
                var heap = new Heap<int>(testCase);
                heap.ToString();
            }
        }
    }
}
