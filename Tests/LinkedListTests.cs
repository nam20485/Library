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
            Console.WriteLine(str);
            str.Should().NotBeNull();
            str = str!.Trim();
            str.Should().NotBeEmpty();
        }

        [Fact]
        public void FindValueWithEmptyList()
        {
            var linkedList = new DataStructures.LinkedList<int>();
            linkedList.Find(1).Should().BeNull();
        }

        [Fact]
        public void FindNonPresentValueWithSingleNode()
        {
            var linkedList = new DataStructures.LinkedList<int>(new [] { 0 });
            linkedList.Find(1).Should().BeNull();
        }

        [Fact]
        public void FindNonPresentValueWithTwoNodes()
        {
            var linkedList = new DataStructures.LinkedList<int>(new[] { 0, 1 });
            linkedList.Find(2).Should().BeNull();
        }

        [Fact]
        public void FindPresentValueWithSingleNode()
        {
            var linkedList = new DataStructures.LinkedList<int>(new[] { 0 });
            var found = linkedList.Find(0);
            found.Should().NotBeNull();
            found!.Value.Should().Be(0);

        }

        [Fact]
        public void FindPresentValueWithTwoNodes_First()
        {
            var linkedList = new DataStructures.LinkedList<int>(new[] { 0, 1 });
            var found = linkedList.Find(0);
            found.Should().NotBeNull();
            found!.Value.Should().Be(0);
        }

        [Fact]
        public void FindPresentValueWithTwoNodes_Second()
        {
            var linkedList = new DataStructures.LinkedList<int>(new[] { 0, 1 });
            var found = linkedList.Find(1);
            found.Should().NotBeNull();
            found!.Value.Should().Be(1);
        }
    }
}
