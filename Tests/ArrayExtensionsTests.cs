using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Library.Utils;

namespace Library.Tests
{
    public class ArrayExtensionsTests
    {
        [Fact]
        public void TestSwap()
        {
            var n = new [] { 1, 2 };
            n.Swap(0, 1);
            n.Should().BeEquivalentTo(new int[] { 2, 1 });
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 3 }, new int[] { 3, 2, 1, 0 })]
        [InlineData(new int[] { 0, 1, 2 }, new int[] { 2, 1, 0 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 0 }, new int[] { 0 })]
        public void TestReverseEntireArray(int[] input, int[] expected)
        {
            var copy1 = new List<int>(input).ToArray();
            copy1.Reverse();
            copy1.Should().BeEquivalentTo(expected);

            var copy2 = new List<int>(input).ToArray();
            copy2.Reverse(0);
            copy2.Should().BeEquivalentTo(expected);

            var copy3 = new List<int>(input).ToArray();
            copy3.Reverse(0, copy3.Length);
            copy3.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 3 }, new int[] { 0, 1, 2, 3 })]
        [InlineData(new int[] { 0, 1, 2 }, new int[] { 0, 1, 2 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 0, 1 })]
        [InlineData(new int[] { 0 }, new int[] { 0 })]
        public void TestReverseIsSymmetrical(int[] input, int[] expected)
        {
            input.Reverse();
            input.Reverse();
            input.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(new int[] { 0, 1, 2, 3 }, 0, 4, new int[] { 3, 2, 1, 0 })]
        [InlineData(new int[] { 0, 1, 2, 3 }, 0, 2, new int[] { 1, 0, 2, 3 })]
        [InlineData(new int[] { 0, 1, 2, 3 }, 2, 2, new int[] { 0, 1, 3, 2 })]
        //[InlineData(new int[] { 0, 1, 2 }, new int[] { 2, 1, 0 })]
        //[InlineData(new int[] { 0, 1 }, new int[] { 1, 0 })]
        [InlineData(new int[] { 0 }, 1, 1, new int[] { 0 })]
        public void TestReversePartOfArray(int[] input, int start, int length, int[] expected)
        {
            input.Reverse(start, length);
            input.Should().BeEquivalentTo(expected);
        }
    }
}
