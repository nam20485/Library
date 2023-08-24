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
        //private static readonly int[][] _testCases = new[]
        //{
        //    new [] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 }
        //};

        [Theory]
        [InlineData(new [] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]        
        public void ValidHeapIsCreatedWithInputs(int[] inputs)
        {
            var heap = new Heap<int>(inputs);
            heap.Count.Should().Be(inputs.Length);
            heap.IsHeap().Should().BeTrue();
            heap.SatisfiesHeapProperty().Should().BeTrue();        
        }

        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void ValidMinHeapIsCreatedWithInputs(int[] inputs)
        {
            var minHeap = new MinHeap<int>(inputs);
            minHeap.Count.Should().Be(inputs.Length);
            minHeap.IsHeap().Should().BeTrue();
            minHeap.SatisfiesHeapProperty().Should().BeTrue();        
        }

        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void HeapSortIsSortedCorrectly(int[] inputs)
        {
            var heap = new Heap<int>(inputs);              
            var list = new DataStructures.List<int>(heap.Sort());
            list.Count.Should().Be(inputs.Length);
            list.IsSorted(DataStructures.List<int>.SortType.MonotonicallyIncreasing).Should().BeTrue();                        
        }

        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void HeapSortIsSortedCorrectly_ReverseComparer(int[] inputs)
        {
            var heap = new Heap<int>(inputs, ReverseDefaultComparer<int>.Instance);            
            var list = new DataStructures.List<int>(heap.Sort());
            list.Count.Should().Be(inputs.Length);
            list.ToList().IsSorted(DataStructures.List<int>.SortType.MonotonicallyDecreasing).Should().BeTrue();        
        }

        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void MinHeapSortIsSortedCorrectly(int[] inputs)
        {
            var minHeap = new MinHeap<int>(inputs);            
            var list = new DataStructures.List<int>(minHeap.Sort());
            list.Count.Should().Be(inputs.Length);
            list.IsSorted(DataStructures.List<int>.SortType.MonotonicallyDecreasing).Should().BeTrue();        
        }

        [Theory]
        [InlineData(new[] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 })]
        public void ToHeapProducesValidHeap(int[] inputs)
        {
            var list = new DataStructures.List<int>(inputs);
            var heap = list.ToHeap();
            heap.Count.Should().Be(inputs.Length);
            heap.IsHeap().Should().BeTrue();
            heap.SatisfiesHeapProperty().Should().BeTrue();        
        }
    }
}
