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
        private static readonly int[][] _testCases = new[]
        {
            new [] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 }
        };

        [Theory]
        [InlineData(new [] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]        
        public void ValidHeapIsCreatedWithInputs(int[] inputs)
        {
            foreach (var testCase in inputs)
            {
                var heap = new Heap<int>(inputs);
                heap.IsHeap().Should().BeTrue();
                heap.SatisfiesHeapProperty().Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void ValidMinHeapIsCreatedWithInputs(int[] inputs)
        {
            foreach (var testCase in inputs)
            {
                var minHeap = new MinHeap<int>(inputs);
                minHeap.IsHeap().Should().BeTrue();
                minHeap.SatisfiesHeapProperty().Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void HeapSortIsSortedCorrectly(int[] inputs)
        {
            foreach (var testCase in inputs)
            {
                var heap = new Heap<int>(inputs);
                heap.Sort();                    
                heap.ToList().IsSorted(DataStructures.List<int>.SortType.MonotonicallyDecreasing).Should().BeTrue();                
            }
        }

        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void HeapSortIsSortedCorrectly_ReverseComparer(int[] inputs)
        {
            foreach (var testCase in inputs)
            {
                var heap = new Heap<int>(inputs, ReverseDefaultComparer<int>.Instance);
                heap.Sort();            
                heap.ToList().IsSorted(DataStructures.List<int>.SortType.MonotonicallyIncreasing).Should().BeTrue();
            }
        }

        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void MinHeapSortIsSortedCorrectly(int[] inputs)
        {
            foreach (var testCase in inputs)
            {
                var minHeap = new MinHeap<int>(inputs);
                minHeap.Sort();
                minHeap.ToList().IsSorted(DataStructures.List<int>.SortType.MonotonicallyIncreasing).Should().BeTrue();
            }
        }

    }
}
