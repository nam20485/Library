namespace Library.Driver
{
    internal class Program
    {
        private static readonly int[][] testCases = new[]
        {
            //Array.Empty<int>(),
            new int[] { 0 },
            new int[] { 0, 1 },
            new int[] { 0, 1, 2 },
            new int[] { 0, 1, 2, 3 }
        };

        static void Main(/*string[] args*/)
        {
            foreach (var testCase in testCases)
            {
                Test(testCase);
            }         
        }

        private static void Test(int[] items)
        {
            var linkedList = new DataStructures.LinkedList<int>(items);
            Console.WriteLine(linkedList);

            linkedList.RemoveLast();
            linkedList.RemoveFirst();
            Console.WriteLine(linkedList);
            Console.WriteLine();
        }
    }
}