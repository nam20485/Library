namespace Library.Tests
{
    public class LinkedListTests
    {
        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new int[] { 0 })]
        [InlineData(new int[] { 0, 1 })]
        [InlineData(new int[] { 0, 1, 2 })]
        [InlineData(new int[] { 0, 1, 2, 3 })]
        public void Test_ToString(int[] items)
        {
            var linkedList = new DataStructures.LinkedList<int>(items);
            var str = linkedList.ToString();
            //Console.WriteLine(str);
            str.Should().NotBeNull();
            str = str!.Trim();
            str.Should().NotBeNullOrWhiteSpace();
        }

        [Fact]
        public void FindValueWithEmptyList()
        {
            var linkedList = new DataStructures.LinkedList<int>();
            linkedList.Contains(1).Should().BeFalse();
        }

        [Fact]
        public void FindNonPresentValueWithSingleNode()
        {
            var linkedList = new DataStructures.LinkedList<int>(new [] { 0 });
            linkedList.Contains(1).Should().BeFalse();
        }

        [Fact]
        public void FindNonPresentValueWithTwoNodes()
        {
            var linkedList = new DataStructures.LinkedList<int>(new[] { 0, 1 });
            linkedList.Contains(2).Should().BeFalse();
        }

        [Fact]
        public void FindPresentValueWithSingleNode()
        {
            var linkedList = new DataStructures.LinkedList<int>(new[] { 0 });
            linkedList.Contains(0).Should().BeTrue();

        }

        [Fact]
        public void FindPresentValueWithTwoNodes_First()
        {
            var linkedList = new DataStructures.LinkedList<int>(new[] { 0, 1 });
            linkedList.Contains(0).Should().BeTrue();
        }

        [Fact]
        public void FindPresentValueWithTwoNodes_Second()
        {
            var linkedList = new DataStructures.LinkedList<int>(new[] { 0, 1 });
            linkedList.Contains(1).Should().BeTrue();            
        }
    }
}
