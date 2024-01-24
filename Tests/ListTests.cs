using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Fact]
        public void Test_AddRange_IntoNonEmptyList()
        {
            var inputs = new int[] { 0, 0, 1, 2, 3 };
            var toAdd = new int[] { 4, 5, 6, 7, 8 };

            var list = new DataStructures.List<int>(inputs);
            list.Count.Should().Be(inputs.Length);

            list.AddRange(toAdd);
            list.Count.Should().Be(inputs.Length+ toAdd.Length);
        }

        [Theory]
        [InlineData(new int[] { 0 })]
        [InlineData(new int[] { 0, 1 })]
        [InlineData(new int[] { 0, 1, 2 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4 })]
        public void Test_RemoveAt_LastIndex(int[] inputs)
        {
            var list = new DataStructures.List<int>(inputs);
            list.Count.Should().Be(inputs.Length);

            list.RemoveAt(inputs.Length-1);

            list.Count.Should().Be(inputs.Length - 1);
        }      

        [Fact]
        public void Test_RemoveLast_OnEmptyList_ThrowsArgumentOutOfRangeException()
        {
            var list = new DataStructures.List<int>();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                list.RemoveLast();
            });
        }
    }
}
