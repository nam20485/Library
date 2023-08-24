using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Tests
{
    public class PriorityQueueTests
    {        
        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void Test_InsertAndForeachMaxPriorityQueue(int[] inputs)
        {
            var pq = new DataStructures.PriorityQueue<int, int>();
            foreach (var input in inputs)
            {
                pq.Insert(input, input);
            }
            var list = new DataStructures.List<int>();
            foreach (var min in pq)
            {
                list.Add(min.Value);
            }
            list.Count.Should().Be(inputs.Length);
            list.IsSorted(DataStructures.List<int>.SortType.MonotonicallyDecreasing);
        }

        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void Test_InsertAndForeachMinPriorityQueue(int[] inputs)
        {
            var pq = new DataStructures.MinPriorityQueue<int, int>();
            foreach (var input in inputs)
            {
                pq.Insert(input, input);
            }
            var list = new DataStructures.List<int>();
            foreach (var min in pq)
            {
                list.Add(min.Value);
            }
            list.Count.Should().Be(inputs.Length);
            list.IsSorted(DataStructures.List<int>.SortType.MonotonicallyIncreasing);
        }
    }
}
