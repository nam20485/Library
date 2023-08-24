using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.DataStructures;

namespace Library.Tests
{
    public class ListTests
    {
        [Theory]
        [InlineData(new int[] { 0, 0, 1, 2, 3 }, DataStructures.List<int>.SortType.MonotonicallyIncreasing, true)]
        [InlineData(new int[] { 0, 0, 1, 2, 3 }, DataStructures.List<int>.SortType.StrictlyIncreasing, false)]
        [InlineData(new int[] { 0, 0, 1, 2, 3 }, DataStructures.List<int>.SortType.MonotonicallyDecreasing, false)]
        [InlineData(new int[] { 0, 0, 1, 2, 3 }, DataStructures.List<int>.SortType.StrictlyDecreasing, false)]
        public void IsSortedIsCorrect(int[] inputs, DataStructures.List<int>.SortType sortType, bool expectedResult)
        {
            var list = Utils.MakeList(inputs);
            list.IsSorted(sortType).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(new int[] { 0, 0, 1, 2, 3 }, true)]
        [InlineData(new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(new int[] { 0 }, true)]
        [InlineData(new int[] { 0, 1 }, true)]
        [InlineData(new int[] { 0, 0, 0 }, true)]
        [InlineData(new int[] { 3, 3, 2, 2, 0 }, false)]
        [InlineData(new int[] { 4, 3, 2, 1, 0 }, false)]        
        [InlineData(new int[] { 1, 0 }, false)]        
        public void Test_IsSortedMonotonicallyIncreasing(int[] inputs, bool expectedResult)
        {
            var list = Utils.MakeList(inputs);
            list.IsSorted(DataStructures.List<int>.SortType.MonotonicallyIncreasing).Should().Be(expectedResult);
        }

        [InlineData(new int[] { 0, 0, 1, 2, 3 }, false)]
        [InlineData(new int[] { 0, 1, 2, 3, 4 }, true)]
        [InlineData(new int[] { 0 }, true)]
        [InlineData(new int[] { 0, 1 }, true)]
        [InlineData(new int[] { 0, 0, 0 }, false)]
        [InlineData(new int[] { 3, 3, 2, 2, 0 }, false)]
        [InlineData(new int[] { 4, 3, 2, 1, 0 }, false)]
        [InlineData(new int[] { 1, 0 }, false)]
        [Theory]        
        public void Test_IsSortedStrcitlyIncreasing(int[] inputs, bool expectedResult)
        {
            var list = Utils.MakeList(inputs);
            list.IsSorted(DataStructures.List<int>.SortType.StrictlyIncreasing).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(new int[] { 0, 0, 1, 2, 3 }, false)]
        [InlineData(new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(new int[] { 0 }, true)]
        [InlineData(new int[] { 0, 1 }, false)]
        [InlineData(new int[] { 0, 0, 0 }, true)]
        [InlineData(new int[] { 3, 3, 2, 2, 0 }, true)]
        [InlineData(new int[] { 4, 3, 2, 1, 0 }, true)]
        [InlineData(new int[] { 1, 0 }, true)]        
        public void Test_IsSortedMonotonicallyDecreasing(int[] inputs, bool expectedResult)
        {
            var list = Utils.MakeList(inputs);
            list.IsSorted(DataStructures.List<int>.SortType.MonotonicallyDecreasing).Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(new int[] { 0, 0, 1, 2, 3 }, false)]
        [InlineData(new int[] { 0, 1, 2, 3, 4 }, false)]
        [InlineData(new int[] { 0 }, true)]
        [InlineData(new int[] { 0, 1 }, false)]
        [InlineData(new int[] { 0, 0, 0 }, false)]
        [InlineData(new int[] { 3, 3, 2, 2, 0 }, false)]
        [InlineData(new int[] { 4, 3, 2, 1, 0 }, true)]
        [InlineData(new int[] { 1, 0 }, true)]            
        public void Test_IsSortedStrictlyDecreasing(int[] inputs, bool expectedResult)
        {
            var list = Utils.MakeList(inputs);
            list.IsSorted(DataStructures.List<int>.SortType.StrictlyDecreasing).Should().Be(expectedResult);
        }       
    }
}
