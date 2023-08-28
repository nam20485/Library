using Library.DataStructures;

namespace Library.Driver
{
    internal class Program
    {
        private static readonly int[][] testCases = new[]
        {
            //new [] { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 },
            //Array.Empty<int>(),
            //new [] { 0 },
            //new [] { 0, 1 },
            //new [] { 0, 1, 2 },
            new [] { 0, 1, 2, 3, 4 }
        };

        static void Main(/*string[] args*/)
        {
            foreach (var testCase in testCases)
            {
                //TestLinkedList(testCase);
                //TestHeap(testCase);
                //TestList(testCase);
                //TestPriorityQueue(testCase);
                //TestMinPriorityQueue(testCase);
                TestCircularBuffer(testCase);
            }         
        }

        private static void TestLinkedList(int[] items)
        {
            var linkedList = new DataStructures.LinkedList<int>(items);
            Console.WriteLine(linkedList);
            var heap = new DataStructures.Heap<int>(items);
            Console.WriteLine(heap);

            linkedList.RemoveLast();
            linkedList.RemoveFirst();
            Console.WriteLine(linkedList);
            Console.WriteLine();
        }

        private static void TestHeap(int[] items)
        {
            var heap = new Heap<int>(items, ReverseDefaultComparer<int>.Instance);
            //heap.Sort();
            ////var a = heap.ToArray<int>();
            ////var l = heap.ToList<int>();
            //var alal = new DataStructures.List<int>(heap.ToList<int>().ToArray());
            Console.WriteLine(heap);
            //Console.WriteLine(alal);
            //var sorted = Heap<int>.HeapSort(items, ReverseDefaultComparer<int>.Instance);
            //Console.WriteLine(new DataStructures.List<int>(sorted));
        }

        private static void TestList(int[] items)
        {
            var list = new DataStructures.List<int>(items);
            Console.WriteLine(list);

            //list.Add
        }     
        
        private static void TestPriorityQueue(int[] inputs)
        {
            var pq = new DataStructures.PriorityQueue<int, int>();
            foreach (var input in inputs)
            {
                pq.Insert(input, input);
            }

            Console.WriteLine($"PQ: {pq}");

            var list = new DataStructures.List<int>();
            
            
            foreach (var min in pq)
            {                
                list.Add(min.Value);
            }

            Console.WriteLine($"List: {list}");
        }

        private static void TestMinPriorityQueue(int[] inputs)
        {
            var pq = new DataStructures.MinPriorityQueue<int, int>();
            foreach (var input in inputs)
            {
                pq.Insert(input, input);
            }

            Console.WriteLine($"MinPQ: {pq}");

            var list = new DataStructures.List<int>();

            foreach (var min in pq)
            {
                list.Add(min.Value);
            }

            Console.WriteLine($"List: {list}");

            Console.WriteLine($"MinPQ.ToList(): {pq.ToList()}");

            Console.WriteLine($"MinPQ.ToArray(): {pq.ToArray()}");
        }

        private static void TestCircularBuffer(int[] inputs)
        {
            var buffer = new CircularBuffer<int>(5);
            Console.WriteLine(buffer);

            buffer.AddRange(inputs);
            Console.WriteLine(buffer);
        }
    }
}