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
            var linkedList = new LinkedList<int>(items);
            var str = linkedList.ToString();
            Console.WriteLine(str);
            str.Should().NotBeNull();
            str = str!.Trim();
            str.Should().NotBeEmpty();
        }
    }
}
